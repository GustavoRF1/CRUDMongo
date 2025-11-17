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

        public async void AdicionarLivro()
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
            await collectionBooks.InsertOneAsync(livro);
        }

        public async void MultiplosLivros()
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
                await collectionBooks.InsertOneAsync(livro);
            }
        }

        public async void ListarUmLivro()
        {
            Console.WriteLine("Digite o Id do livro: ");
            string id = Console.ReadLine();
            var livro = await collectionBooks.FindAsync(b => b.Id == id).Result.FirstOrDefaultAsync();
            if (livro == null)
            {
                Console.WriteLine("Livro não encontrado!");
                return;
            }
            Console.WriteLine($"{livro}\n");
            Console.ReadKey();
        }

        public async void ListarTodosLivros()
        {
            var livros = await collectionBooks.FindAsync(_ => true).Result.ToListAsync();
            foreach (var livro in livros)
            {
                Console.WriteLine($"{livro}\n");
            }
            Console.ReadKey();
        }

        public async void AtualizarLivro()
        {
            int ano;
            Console.WriteLine("Digite o Id do livro que deseja atualizar: ");
            string id = Console.ReadLine();
            var livro = await collectionBooks.FindAsync(b => b.Id == id).Result.FirstOrDefaultAsync();
            if (livro == null)
            {
                Console.WriteLine("Livro não encontrado!");
                return;
            }
            Console.WriteLine("Digite o novo título do livro: ");
            string tituloDigitado = Console.ReadLine() ?? livro.Title;

            string titulo = string.IsNullOrEmpty(tituloDigitado) ? livro.Title : tituloDigitado;

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
            await collectionBooks.UpdateOneAsync(b => b.Id == id, update);
        }

        public async void DeletarLivro()
        {
            Console.WriteLine("Digite o Id do livro que deseja deletar: ");
            string id = Console.ReadLine();
            var livro = collectionBooks.Find(b => b.Id == id).FirstOrDefault();
            if (livro == null)
            {
                Console.WriteLine("Livro não encontrado!");
                return;
            }
            await collectionBooks.DeleteOneAsync(b => b.Id == id);
        }
    }
}
