# importing the requests library 
import requests 
import json
import warnings
warnings.filterwarnings("ignore")
import http.client
import ssl
# api-endpoint 
URL = "https://localhost:5001/api/car/"
URL1 = "https://localhost:5001/api/car/2" 
r = requests.get(url = URL,verify=False) 
# extracting data in json format 
data = r.json() 
print(data)
port=5001
context = ssl._create_unverified_context()
conn = http.client.HTTPSConnection('localhost',port=5001 ,context=context)
headers = {'Content-type': 'application/json'}

foo = {"Id":4,"CarName":"Celerio","Color":"Black","Company":"Maruti","Engine":"Normal"}
json_data = json.dumps(foo)

conn.request('POST','/api/car/', json_data, headers)

response = conn.getresponse()
print(response.read().decode())