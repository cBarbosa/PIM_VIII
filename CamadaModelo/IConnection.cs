using System.Collections.Generic;

namespace PIM_VIII.Model
{
    interface IConnection<TEntity> where TEntity : class
    {
        List<TEntity> GetAll();
        TEntity GetById(int id);
        void Insere(TEntity obj);
        void Atualiza(TEntity obj);
        void Exclui(int id);
    }
}