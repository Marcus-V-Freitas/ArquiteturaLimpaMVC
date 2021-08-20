namespace ArquiteturaLimpaMVC.Dominio.Entidades
{
    public abstract class Entity
    {
        public int Id { get; protected set; }

        protected abstract void ValidarDominio();
    }
}