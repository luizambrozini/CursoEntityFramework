using Ecomerce.Data.Contexts;

namespace Ecomerce.Data.Repositories
{

    #region IUsuarioRepository
    public interface IUsuarioRepository
    {
        List<Usuario> Get();
        Usuario Get(int id);
        void Add(Usuario usuario);
        void Update(Usuario usuario);
        void Delete(int id);
    }
    #endregion

    #region UsuarioRepository
    public class UsuarioRepository : IUsuarioRepository
    {
        public static List<Usuario> _db = new List<Usuario>();
        private EcomerceContext _context;
        public UsuarioRepository(EcomerceContext context)
        {
            _context = context;
        }

        public List<Usuario> Get()
        {
            return _context.Usuarios.OrderBy(u => u.Nome).ToList();
        }

        public Usuario Get(int id)
        {
            return _context.Usuarios.Find(id)!;
        }

        public void Add(Usuario usuario)
        {
            _context.Usuarios.Add(usuario);
            _context.SaveChanges();
        }

        public void Update(Usuario usuario)
        {
            _context.Usuarios.Update(usuario);
            _context.SaveChanges();

        }

        public void Delete(int id)
        {
            _context.Usuarios.Remove(Get(id));
        }

    }
    #endregion

}
