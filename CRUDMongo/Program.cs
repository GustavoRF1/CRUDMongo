using MongoDB.Driver;
using CRUDMongo.Menus;

#region MongoDB Conexão + Collections

var client = new MongoClient("mongodb+srv://gustavo13rocha_db_user:lugv08R7voC9WQ62@interacaomongo.oqxsacl.mongodb.net/");

var database = client.GetDatabase("Library");

var authorsServices = new CRUDMongo.Services.AuthorsServices(database);

var booksServices = new CRUDMongo.Services.BooksServices(database, authorsServices);
#endregion

Menus menu = new Menus(authorsServices, booksServices);

int op = 0;

do
{
    menu.Menu();
} while (op != 0);