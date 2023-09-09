using ControleDeCadastros.Models;
using Microsoft.EntityFrameworkCore;

namespace ControleDeCadastros.Data
{
    public class BancoContext : DbContext
    {
        public BancoContext(DbContextOptions<BancoContext> options) : base(options)
        {

        }

       public DbSet<ContatosModel> ContatosTabel { get; set; }
    }
}
