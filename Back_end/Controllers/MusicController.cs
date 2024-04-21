using Back_end.Data;
using Back_end.Models;
using Microsoft.AspNetCore.Mvc;


namespace Back_end.Controllers
{
    // Declara a classe MusicController que herda de Controller
    public class MusicController : Controller
    {
        // Declara uma variável privada somente leitura do tipo LiveMusicDbContext
        private readonly LiveMusicDbContext _context;

        // Declara o construtor da classe MusicController que recebe um parâmetro do tipo LiveMusicDbContext
        public MusicController(LiveMusicDbContext context)
        {
            // Atribui o parâmetro context à variável _context
            _context = context;
        }

        // Declara o método UploadMusic que recebe um parâmetro do tipo IFormFile
        public IActionResult UploadMusic(IFormFile file)
        {
            // Verifica se o arquivo não é nulo e se o tamanho do arquivo é maior que zero
            if (file != null && file.Length > 0)
            {
                // Declara uma variável do tipo byte array para armazenar os dados do arquivo
                byte[] musicData;

                // Cria um objeto BinaryReader para ler os dados do arquivo
                using (var binaryReader = new BinaryReader(file.OpenReadStream()))
                {
                    // Lê os dados do arquivo e atribui à variável musicData
                    musicData = binaryReader.ReadBytes((int)file.Length);
                }

                // Cria um novo objeto do tipo MusicModel
                var music = new MusicModel()
                {
                    // Atribui o nome do arquivo à propriedade Name
                    Name = file.FileName,

                    // Atribui os dados do arquivo à propriedade MusicData
                    MusicData = musicData
                };

                // Adiciona o objeto music ao contexto do banco de dados
                _context.Musics.Add(music);

                // Salva as alterações no banco de dados
                _context.SaveChanges();
            }

            // Redireciona para a ação Index
            return RedirectToAction("Index");
        }
    }
}