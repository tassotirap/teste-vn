# teste-vn

## Criar os dockers abaixo
 - docker run -d --hostname rabbit-vn --name rabbit-vn -p 15672:15672 rabbitmq:3-management
 - docker run -d --name db -p 8091-8094:8091-8094 -p 11210:11210 couchbase
 
## Acessar http://127.0.0.1:8091 e configurar um novo Bucket com nome viajanet-webaccess

# Criar uma view "webaccess-browsers"

	Map:
	function (doc, meta) {
		emit(doc.browser, 1);
	}
	
	Reduce:
	_count
	
# Criar uma view "webaccess-time"

	Map:
	function (doc, meta) {
		var date = new Date(doc.data);
		var newDate = new Date(date.getFullYear() + "-" + (date.getMonth() + 1) + "-" + date.getDate() + " " + date.getHours() + ":00:00")
		emit(newDate, 1);
	}
	
	Reduce:
	_count