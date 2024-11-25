using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer
{

    public interface IRepository<T>
    {
        /// <summary>
        /// Метод, сохраняющий сущность в базу данных
        /// </summary>
        /// <param name="obj"> Сохраняемая сущность</param>
        void Create(T obj);

        /// <summary>
        /// Метод, достающий из таблицы все сущности
        /// </summary>
        /// <returns>Список сущностей</returns>
        List<T> ReadAll();

        /// <summary>
        /// Метод, возвращающий сущность по ее id
        /// </summary>
        /// <param name="id"></param>
        /// <returns>Сущнсоть</returns>
        T ReadById(int id);

        /// <summary>
        /// Обновляет сущность внутри базы данных
        /// </summary>
        /// <param name="obj">Сущность</param>
        void Update(T obj);

        /// <summary>
        /// Метод, удаляющий сущность из БД
        /// </summary>
        /// <param name="id">id сущности в БД</param>
        void Delete(int id);
    }
}
