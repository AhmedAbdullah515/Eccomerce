namespace Eccomerce.Repo
{
    public interface IGenariceRepo<T> where T : class
    {
        public Task Add(T entity);
        public void Delete(int Id);
        public Task<T> GetById(int Id);
        public void Update(T entity);
        public Task<IEnumerable<T>> GetAll();
    }
}
