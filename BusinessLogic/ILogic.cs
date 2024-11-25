using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic
{
    public interface ILogic
    {

        /// <summary>
        /// Метод проверяет строки на валидность и добавляет студента с список
        /// </summary>
        /// <param name="Name">ФИО студента</param>
        /// <param name="Speciality">Специальность</param>
        /// <param name="Group">Группа</param>
        /// <returns>Возвращает бульку, говорящую о том выполнена операция успешно или нет</returns>
        bool AddStudent(string Name, string Speciality, string Group);

        /// <summary>
        /// Метод проверяет что индекс валиден и удаляет студента по индексу
        /// </summary>
        /// <param name="id">Индекс студента в списке</param>
        /// <returns>Возвращает бульку, говорящую о том выполнена операция успешно или нет</returns>
        bool RemoveStudent(int id);

        /// <summary>
        /// Обновляет студента по заданному индексу. Проверяет изменились ли значения и не пустые ли они и изменяет, если пришли новые значения
        /// </summary>
        /// <param name="index">Индекс студента вв списке</param>
        /// <param name="Name">Имя студента</param>
        /// <param name="Speciality">Специальность студента</param>
        /// <param name="Group">Группа студента</param>
        /// <returns>Возвращает бульку, говорящую о том выполнена операция успешно или нет</returns>
        bool UpdateStudent(int id, string Name, string Speciality, string Group);


        /// <summary>
        /// Подготавливает словарь для гистограммы. Возвращает словар <строка, число>
        /// </summary>
        /// <returns>Возвращает словарь(string,int) в котором строка=специальность инт=количество студентов</returns>
        Dictionary<string, int> GetSpecialityMap();

        /// <summary>
        /// Создает рандомных студентов, по количеству равных count
        /// </summary>
        /// <param name="count">Количество студентов, которое необходимо создать</param>
        void CreateRandomStudents(int count);

        /// <summary>
        /// Метод возвращает словарь для отображения студентов во вьюхе
        /// </summary>
        /// <returns>Врозвращает Dictionary<int, Dictionary<string, string>> в котором int=индекс студента, внутренний словарь = хранитель переменных </returns>
        Dictionary<int, Dictionary<string, string>> GetStudentsAsMap();

    }
}
