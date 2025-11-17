using CRUDMongo.Services;
using CRUDMongo.Models;

namespace CRUDMongo.Menus
{


    public class Menus
    {
        private AuthorsServices AuthorsServices;
        private BooksServices BooksServices;

        public Menus(AuthorsServices authorsServices, BooksServices booksServices)
        {
            this.AuthorsServices = authorsServices;
            this.BooksServices = booksServices;
        }

        public void Menu()
        {
            Console.Clear();
            Console.WriteLine("--- Menu ---");
            Console.WriteLine("1- Adicionar");
            Console.WriteLine("2- Listar");
            Console.WriteLine("3- Atualizar");
            Console.WriteLine("4- Deletar");
            Console.WriteLine("0- Sair");
            Console.Write("Escolha uma opção: ");
            int op = int.Parse(Console.ReadLine());

            switch (op)
            {
                case 1:
                    Console.Clear();
                    MenuAdicionar();
                    break;
                case 2:
                    Console.Clear();
                    MenuListar();
                    break;
                case 3:
                    Console.Clear();
                    MenuAtualizar();
                    break;
                case 4:
                    Console.Clear();
                    MenuDeletar();
                    break;
                case 0:
                    Console.WriteLine("Saindo...");
                    break;
                default:
                    Console.WriteLine("Opção inválida!");
                    break;
            }
        }

        public void MenuAdicionar()
        {
            Console.WriteLine("--- Adicionar ---");
            Console.WriteLine("1- Apenas um Autor");
            Console.WriteLine("2- Múltiplos Autores");
            Console.WriteLine("3- Apenas um Livro");
            Console.WriteLine("4- Múltiplos Livros");
            Console.WriteLine("0- Voltar");
            Console.Write("Escolha uma opção: ");
            int op = int.Parse(Console.ReadLine());

            switch (op)
            {
                case 1:
                    Console.Clear();
                    this.AuthorsServices.AdicionarAutor();
                    break;
                case 2:
                    Console.Clear();
                    this.AuthorsServices.MultiplosAutores();
                    break;
                case 3:
                    Console.Clear();
                    this.BooksServices.AdicionarLivro();
                    break;
                case 4:
                    Console.Clear();
                    this.BooksServices.MultiplosLivros();
                    break;
                case 0:
                    Console.Clear();
                    Menu();
                    break;
                default:
                    Console.WriteLine("Opção inválida!");
                    break;
            }
            Menu();
        }
        public void MenuListar()
        {
            Console.WriteLine("--- Listar ---");
            Console.WriteLine("1- Apenas um Autor");
            Console.WriteLine("2- Todos os Autores");
            Console.WriteLine("3- Apenas um Livro");
            Console.WriteLine("4- Todos os Livros");
            Console.WriteLine("0- Voltar");
            Console.Write("Escolha uma opção: ");
            int op = int.Parse(Console.ReadLine());

            switch (op)
            {
                case 1:
                    Console.Clear();
                    this.AuthorsServices.ListarUmAutor();
                    break;
                case 2:
                    Console.Clear();
                    this.AuthorsServices.ListarTodosAutores();
                    break;
                case 3:
                    Console.Clear();
                    this.BooksServices.ListarUmLivro();
                    break;
                case 4:
                    Console.Clear();
                    this.BooksServices.ListarTodosLivros();
                    break;
                case 0:
                    Console.Clear();
                    Menu();
                    break;
                default:
                    Console.WriteLine("Opção inválida!");
                    break;
            }
            Menu();
        }
        public void MenuAtualizar()
        {
            Console.WriteLine("--- Atualizar ---");
            Console.WriteLine("1- Autor");
            Console.WriteLine("2- Livro");
            Console.WriteLine("0- Voltar");
            Console.Write("Escolha uma opção: ");
            int op = int.Parse(Console.ReadLine());

            switch (op)
            {
                case 1:
                    Console.Clear();
                    this.AuthorsServices.AtualizarAutor();
                    break;
                case 2:
                    Console.Clear();
                    this.BooksServices.AtualizarLivro();
                    break;
                case 0:
                    Console.Clear();
                    Menu();
                    break;
                default:
                    Console.WriteLine("Opção inválida!");
                    break;
            }
            Menu();
        }
        public void MenuDeletar()
        {
            Console.WriteLine("--- Deletar ---");
            Console.WriteLine("1- Autor");
            Console.WriteLine("2- Livro");
            Console.WriteLine("0- Voltar");
            Console.Write("Escolha uma opção: ");
            int op = int.Parse(Console.ReadLine());

            switch (op)
            {
                case 1:
                    Console.Clear();
                    this.AuthorsServices.DeletarAutor();
                    break;
                case 2:
                    Console.Clear();
                    this.BooksServices.DeletarLivro();
                    break;
                case 0:
                    Console.Clear();
                    Menu();
                    break;
                default:
                    Console.WriteLine("Opção inválida!");
                    break;
            }
            Menu();
        }
    }
}
