const MongoClient = require("mongodb").MongoClient;
const test = require("assert");
const convertHrtime = require('convert-hrtime');
const uuidv4 = require('uuid/v4');


const url = "mongodb://localhost:27017";
// Database Name
const dbName = "Node";

global.insertCount = 0;
global.CodigosUsados = [];

// MongoClient.connect(url, function(err, client) {

//     test.equal(null, err);
//     console.log("Successfully connected to server");

//     const col = client.db(dbName).collection("node");

//     // Find some documents in our collection
//     col.find({}).toArray(function(err, docs) {

//         // Print the documents returned
//         docs.forEach(function(doc) {
//             console.log(doc);
//         });

//         // Close the client
//         client.close();
//     });

//     // Declare success
//     console.log("Called find()");
// });




async function Tests() {
    Insert().then(
        Find()
    );

}



function RegistrarLogInsert(start, end, diff, msg, client) {

    const col = client.db("Log").collection("NodeInsert");

    col.insertOne({
        Start: start,
        End: end,
        TimeDifference: diff,
        Msg: msg,
    });
}

function RegistrarLogFind(start, end, diff, msg, client) {
    const col = client.db("Log").collection("NodeFind");

    col.insertOne({
        Start: start,
        End: end,
        TimeDifference: diff,
        Msg: msg
    });
}

function RegistrarLog(start, end, diff, msg, client, operation) {
    const col = client.db("Log").collection("Node");

    col.insertOne({
        Start: start,
        End: end,
        TimeDifference: diff,
        Msg: msg,
        Operation: operation
    });
}

async function Insert() {
    return new Promise(resolve => {
        MongoClient.connect(url, function (err, client) {
            test.equal(null, err);
            console.log("Successfully connected to server");

            const col = client.db(dbName).collection("registro");

            InsertLoop(col, client).then(resolve());

        });
    });
}

async function InsertLoop(col, client) {

    return new Promise(resolve => {

        var codigo = uuidv4();
        CodigosUsados.push(codigo);
        let person = {
            Codigo: codigo,
            Nome: "xuxu",
            CodigoFiscal: 123
        };

        var start = new Date();
        var startTime = process.hrtime();

        col.insertOne(person).then(() => {
            var end = new Date();
            var diff = convertHrtime(process.hrtime(startTime));

            RegistrarLog(start, end, diff.milliseconds, insertCount, client, "Insert");

            if (insertCount < 1000) {
                insertCount += 1;
                InsertLoop(col, client);
            } else {
                // client.close();
            }
        }).catch((e) => {
            console.log(e)
        });

        resolve();
    });
}


async function Find() {

    return new Promise(resolve => {

        MongoClient.connect(url, function (err, client) {

            test.equal(null, err);
            console.log("Successfully connected to server");

            const col = client.db(dbName).collection("registro");
            FindLoop(col, client).then(resolve());
            // client.close();
        });
    });
}

function FindLoop(col, client) {

    return new Promise(resolve => {
        CodigosUsados.forEach(function (codigo) {
            var start = new Date();
            var startTime = process.hrtime();
            // Find some documents in our collection
            col.findOne({ Codigo: codigo }, (err, result) => {

                var end = new Date();
                var diff = convertHrtime(process.hrtime(startTime));
                RegistrarLog(start, end, diff.milliseconds, insertCount, client, "Find");
                console.log(codigo);
            });
        });
        resolve();
    });
}

async function Delete() {

    return new Promise(resolve => {

        MongoClient.connect(url, function (err, client) {

            test.equal(null, err);
            console.log("Successfully connected to server");

            const col = client.db(dbName).collection("registro");
            DeleteLoop(col, client).then(resolve());
        });
    });
}

function DeleteLoop(col, client) {

    return new Promise(resolve => {

        var start = new Date();
        var startTime = process.hrtime();

        CodigosUsados.forEach(function (codigo) {

            // Find some documents in our collection
            col.deleteOne({ Codigo: codigo }, (err, result) => {

                var end = new Date();
                var diff = convertHrtime(process.hrtime(startTime));
                RegistrarLog(start, end, diff.milliseconds, insertCount, client, "Delete");
            });
        });

        // client.close();
        resolve();
    });
}

Tests();