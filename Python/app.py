from pymongo import MongoClient
import datetime
import uuid
# 27017 is the default port number for mongodb
client = MongoClient('localhost', 27017)

db = client.python
col = db.registro

CodigosUsados = []


def Insert():
    for item in range(0, 1000):
        codigo = str(uuid.uuid4())
        CodigosUsados.append(codigo)
        reg = {
            "Codigo": codigo,
            "Nome": "Ancalagon",
            "CodigoFiscal": "3356985258",
        }

        inicio = datetime.datetime.now()
        col.insert_one(reg)
        fim = datetime.datetime.now()
        RegistrarLog(inicio, fim, item, "Insert")

def Find():
    for codigo in CodigosUsados:
        inicio = datetime.datetime.now()
        col.find_one({"Codigo": codigo})
        fim = datetime.datetime.now()
        RegistrarLog(inicio, fim, codigo, "Find")


def Update():
    for codigo in CodigosUsados:
        inicio = datetime.datetime.now()
        col.update_one({"Codigo": codigo}, {"$set":{"Nome":"Alterado"}})
        fim = datetime.datetime.now()
        RegistrarLog(inicio, fim, codigo, "Update")



def Delete():
    for codigo in CodigosUsados:
        inicio = datetime.datetime.now()
        col.delete_one({"Codigo": codigo})
        fim = datetime.datetime.now()
        RegistrarLog(inicio, fim, "", "Delete")



def RegistrarLog(inicio, fim, msg, operation):
    diff = fim - inicio
    timeDifference = float(diff.total_seconds()) * 1000

    client.Log.Python.insert_one({
        "Start": inicio,
        "End": fim,
        "TimeDifference": timeDifference,
        "Msg": msg,
        "Operation": operation
    })


def Test():
    Insert()
    Find()
    Update()
    Delete()


Test()