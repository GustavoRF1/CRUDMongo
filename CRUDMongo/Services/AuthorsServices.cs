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

        public async void AdicionarAutor()
        {
            Console.WriteLine("Digite o nome do autor: ");
            string nome = Console.ReadLine();
            Console.WriteLine("Digite o país do autor: ");
            string pais = Console.ReadLine();
            Authors autor = new Authors(nome, pais);
            await collectionAuthors.InsertOneAsync(autor);
        }

        public async void MultiplosAutores()
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
                await collectionAuthors.InsertOneAsync(autor);
            }
        }

        public async void ListarUmAutor()
        {
            Console.WriteLine("Digite o Id do autor: ");
            string id = Console.ReadLine();
            var autor = await collectionAuthors.FindAsync(a => a.Id == id).Result.FirstOrDefaultAsync();
            if (autor == null)
            {
                Console.WriteLine("Autor não encontrado!");
                return;
            }
            Console.Clear();
            Console.WriteLine($"{autor}\n");
            Console.ReadKey();
        }

        public async void ListarTodosAutores()
        {
            var autores = await collectionAuthors.FindAsync(_ => true).Result.ToListAsync();
            foreach (var autor in autores)
            {
                Console.WriteLine($"{autor}\n");
            }
            Console.ReadKey();
        }

        public async void AtualizarAutor()
        {
            Console.WriteLine("Digite o Id do autor que deseja atualizar: ");
            string id = Console.ReadLine();
            if (!ValidarAutor(id))
            {
                return;
            }

            var autor = await collectionAuthors.FindAsync(a => a.Id == id).Result.FirstOrDefaultAsync();

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
        }

        public async void DeletarAutor()
        {
            Console.WriteLine("Digite o Id do autor que deseja deletar: ");
            string id = Console.ReadLine();
            if (!ValidarAutor(id))
            {
                return;
            }
            await collectionAuthors.DeleteOneAsync(a => a.Id == id);
        }
    }
}
