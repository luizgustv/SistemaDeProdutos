using Microsoft.EntityFrameworkCore;
using SistemaDeProdutos.Models;

namespace SistemaDeProdutos.Data
{
    public class TipoProdutoContext: DbContext
    {
        public TipoProdutoContext(DbContextOptions<TipoProdutoContext> options) : base(options)
        {
        }

        public DbSet<TipoProduto> TipoProdutos { get; set; }
    }
}
