using MongoDB.Driver;
using CRUDMongo.Models;

namespace CRUDMongo.Services
{
    public class AuthorsServices
    {
        public IMongoCollection<Authors> collectionAuthors;

        public AuthorsServices(IMongoDatabase database)
        {
            collectionAuthors = database.GetCollection<Authors>("Authors");
        }

        public bool ValidarAutor(string id)
        {
            string idFormatado = id.PadLeft(24, '0');
            var autor = collectionAuthors.Find(a => a.Id == idFormatado).FirstOrDefault();
            if (autor == null)
            {
                Console.WriteLine("Autor não existe!");
                return false;
            }
            return true;
        }

        public void AdicionarAutor()
        {
            Console.WriteLine("Digite o nome do autor: ");
            string nome = Console.ReadLine();
            Console.WriteLine("Digite o país do autor: ");
            string pais = Console.ReadLine();
            Authors autor = new Authors(nome, pais);
            collectionAuthors.InsertOne(autor);
            Console.WriteLine("Autor adicionado!");
            Console.ReadKey();
        }

        public void MultiplosAutores()
        {
            Console.WriteLine("Digite a quantidade de autores que deseja adiconar: ");
            int quantidade = int.Parse(Console.ReadLine());

            List<Authors> autores = new List<Authors>();

            for (int i = 0; i < quantidade; i++)
            {
                Console.WriteLine($"Autor {i + 1}");
                Console.Write("Nome: ");
                string nome = Console.ReadLine();
                Console.Write("País: ");
                string pais = Console.ReadLine();
                Authors autor = new Authors(nome, pais);
                autores.Add(autor);
            }

            foreach (var autor in autores)
            {
                collectionAuthors.InsertOne(autor);
            }
            Console.WriteLine("Autores adicionados!");
            Console.ReadKey();
        }

        public void ListarUmAutor()
        {
            Console.WriteLine("Digite o Id do autor: ");
            string id = Console.ReadLine();
            var autor = collectionAuthors.Find(a => a.Id == id).FirstOrDefault();
            if (autor == null)
            {
                Console.WriteLine("Autor não encontrado!");
                return;
            }
            Console.WriteLine($"{autor}\n");
            Console.ReadKey();
        }

        public void ListarTodosAutores()
        {
            var autores = collectionAuthors.Find(_ => true).ToList();
            foreach (var autor in autores)
            {
                Console.WriteLine($"{autor}\n");
            }
            Console.ReadKey();
        }

        public void AtualizarAutor()
        {
            Console.WriteLine("Digite o Id do autor que deseja atualizar: ");
            string id = Console.ReadLine();
            if (!ValidarAutor(id))
            {
                return;
            }

            var autor = collectionAuthors.Find(a => a.Id == id).FirstOrDefault();

            string nome, pais;

            Console.WriteLine("Digite o novo nome do autor: ");
            string nomeDigitado = Console.ReadLine();

            nome = string.IsNullOrEmpty(nomeDigitado) ? autor.Name : nomeDigitado;

            Console.WriteLine("Digite o novo país do autor: ");
            string paisDigitado = Console.ReadLine();

            pais = string.IsNullOrEmpty(paisDigitado) ? autor.Country : paisDigitado;

            var update = Builders<Authors>.Update
                .Set(a => a.Name, nome)
                .Set(a => a.Country, pais);
            collectionAuthors.UpdateOne(a => a.Id == id, update);
            Console.WriteLine("Autor atualizado!");
            Console.ReadKey();
        }

        public void DeletarAutor()
        {
            Console.WriteLine("Digite o Id do autor que deseja deletar: ");
            string id = Console.ReadLine();
            if (!ValidarAutor(id))
            {
                return;
            }
            collectionAuthors.DeleteOne(a => a.Id == id);
            Console.WriteLine("Autor deletado!");
            Console.ReadKey();
        }
    }
}
