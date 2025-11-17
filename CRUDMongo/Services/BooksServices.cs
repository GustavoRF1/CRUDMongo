using MongoDB.Driver;
using CRUDMongo.Models;
using CRUDMongo.Services;

namespace CRUDMongo.Services
{
    public class BooksServices
    {
        public IMongoCollection<Books> collectionBooks;

        public AuthorsServices authorsServices;

        public BooksServices(IMongoDatabase database, AuthorsServices authorsServices)
        {
            collectionBooks = database.GetCollection<Books>("Books");
            this.authorsServices = authorsServices;
        }

        public void AdicionarLivro()
        {
            Console.WriteLine("Digite o título do livro: ");
            string titulo = Console.ReadLine();
            Console.WriteLine("Digite o Id do autor: ");
            string idAutor = Console.ReadLine();
            if (!this.authorsServices.ValidarAutor(idAutor))
            {
                return;
            }
            Console.WriteLine("Digite o ano de publicação: ");
            int ano = int.Parse(Console.ReadLine());
            Books livro = new Books(titulo, idAutor, ano);
            collectionBooks.InsertOne(livro);
            Console.WriteLine("Livro adicionado!");
            Console.ReadKey();
        }

        public void MultiplosLivros()
        {
            Console.WriteLine("Digite a quantidade de livros que deseja adicionar: ");
            int quantidade = int.Parse(Console.ReadLine());

            List<Books> livros = new List<Books>();

            for (int i = 0; i < quantidade; i++)
            {
                Console.WriteLine($"Livro {i + 1}");
                Console.Write("Título: ");
                string nome = Console.ReadLine();
                Console.Write("Id do Autor: ");
                string idAutor = Console.ReadLine();
                if (!authorsServices.ValidarAutor(idAutor))
                {
                    i--;
                    continue;
                }
                Console.Write("Ano de Publicação: ");
                int ano = int.Parse(Console.ReadLine());
                Books livro = new Books(nome, idAutor, ano);
                livros.Add(livro);
            }

            foreach (var livro in livros)
            {
                collectionBooks.InsertOne(livro);
            }
            Console.WriteLine("Livros adicionados!");
            Console.ReadKey();
        }

        public void ListarUmLivro()
        {
            Console.WriteLine("Digite o Id do livro: ");
            string id = Console.ReadLine();
            var livro = collectionBooks.Find(b => b.Id == id).FirstOrDefault();
            if (livro == null)
            {
                Console.WriteLine("Livro não encontrado!");
                return;
            }
            Console.WriteLine($"\n{livro}");
            Console.ReadKey();
        }

        public void ListarTodosLivros()
        {
            var livros = collectionBooks.Find(_ => true).ToList();
            foreach (var livro in livros)
            {
                Console.WriteLine($"\n{livro}");
            }
            Console.ReadKey();
        }

        public void AtualizarLivro()
        {
            int ano;
            Console.WriteLine("Digite o Id do livro que deseja atualizar: ");
            string id = Console.ReadLine();
            var livro = collectionBooks.Find(b => b.Id == id).FirstOrDefault();
            if (livro == null)
            {
                Console.WriteLine("Livro não encontrado!");
                return;
            }
            Console.WriteLine("Digite o novo título do livro: ");
            string titulo = Console.ReadLine() ?? livro.Title;
            Console.WriteLine("Digite o novo Id do autor: ");
            string idAutor = Console.ReadLine() ?? livro.AuthorId;
            if (!authorsServices.ValidarAutor(idAutor))
            {
                return;
            }
            Console.WriteLine("Digite o novo ano de publicação: ");
            string anoInput = Console.ReadLine();
            if (string.IsNullOrEmpty(anoInput))
            {
                ano = livro.Year;
            }
            else
            {
                ano = int.Parse(anoInput);
            }
            var update = Builders<Books>.Update
                .Set(b => b.Title, titulo)
                .Set(b => b.AuthorId, idAutor)
                .Set(b => b.Year, ano);
            collectionBooks.UpdateOne(b => b.Id == id, update);
            Console.WriteLine("Livro atualizado!");
            Console.ReadKey();
        }

        public void DeletarLivro()
        {
            Console.WriteLine("Digite o Id do livro que deseja deletar: ");
            string id = Console.ReadLine();
            var livro = collectionBooks.Find(b => b.Id == id).FirstOrDefault();
            if (livro == null)
            {
                Console.WriteLine("Livro não encontrado!");
                return;
            }
            collectionBooks.DeleteOne(b => b.Id == id);
            Console.WriteLine("Livro deletado!");
            Console.ReadKey();
        }
    }
}
