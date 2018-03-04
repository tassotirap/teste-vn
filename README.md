# teste-vn

## Criar os dockers abaixo
 - docker run -d --hostname rabbit-vn --name rabbit-vn -p 15672:15672 rabbitmq:3-management
 - docker run -d --name db -p 8091-8094:8091-8094 -p 11210:11210 couchbase
 
## Acessar http://127.0.0.1:8091 e configurar um novo Bucket com nome viajanet-webaccess