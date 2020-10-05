using System.Text.RegularExpressions;

namespace ControlOfPracticalClasses
{
    static class MyFunction
    {

        //Переводит с русского на английский(транслитом)
        public static string Translit(string s)
        {
            string[] rus = { "а", "б", "в", "г", "д", "е", "ё", "ж", "з", "и", "й", "к", "л", "м", "н", "о", "п", "р", "с", "т", "у", "ф", "х", "ц", "ч", "ш", "щ", "ы", "э", "ю", "я" };
            string[] eng = { "a", "b", "v", "g", "d", "e", "yo", "zh", "z", "i", "y", "k", "l", "m", "n", "o", "p", "r", "s", "t", "u", "f", "h", "ts", "ch", "sh", "sch", "y", "e", "yu", "ya" };

            s = s.ToLower();

            for (int i = 0; i < s.Length; i++)
            {
                if (s[i] == 'ь' || s[i] == 'ъ')
                {
                    s = s.Remove(i, 1);
                    i--;
                }
            }

            for (int i = 0; i < rus.Length; i++)
            {
                s = s.Replace(rus[i], eng[i]);
            }

            return s;
        }

        //Удаляет все пробелы в начале строки и в конце
        //заменяет все пробельные символы на один пробел
        public static string FixSpace(string s)
        {

            string patternSpaceBegin = @"^\s+";//Паттерн для удаления всех пробельных символов в начале строки
            string patternSpaceEnd = @"\s+$";//Паттерн для удаления всех пробельных символов перед концом строки
            string patternSpace = @"\s+";//Паттерн для замены всех пробельных символов на один пробел

            s = Regex.Replace(s, patternSpaceBegin, "");//удаление пробельных смволов в начале строки
            s = Regex.Replace(s, patternSpaceEnd, "");//удаление пробельных смволов перед концом строки
            s = Regex.Replace(s, patternSpace, " ");  //замена всех пробельных символов на один пробел

            return s;
        }

        //удаление всех пробельных смволов
        public static string DelSpace(string s)
        {
            string patternSpace = @"\s";//Паттерн для удаления всех пробельных символов

            s = Regex.Replace(s, patternSpace, "");//удаление всех пробельных смволов

            return s;
        }

        //Проверяет являеться ли строка ФИО
        public static bool CheckFIO(string s)
        {
            s = FixSpace(s);

            string patternRusFIO = @"[А-Я][а-я]*\s{1}[А-Я][а-я]*\s?([А-Я][а-я])*$";
            string patternEngFIO = @"[A-Z][a-z]*\s{1}[A-Z][a-z]*\s?([A-Z][a-z])*$";

            if (Regex.IsMatch(s, patternRusFIO)) return true;
            else if (Regex.IsMatch(s, patternEngFIO)) return true;
            else return false;
        }

        //Создает логин на основании ФИО
        public static string GetLogin(string fio)
        {
            fio = FixSpace(fio);

            fio = Regex.Match(fio, @"^[A-ZА-Я][a-zа-я]*\s").ToString();

            fio = fio.Remove(fio.Length - 1);

            return Translit(fio);
        }

        //Создает пороль на основании ФИО
        public static string GetPassword(string fio)
        {
            fio = FixSpace(fio);

            MatchCollection collection = Regex.Matches(fio, @"[A-ZА-Я][a-zа-я]*(\s|$)");

            return Translit(collection[1].Value);
        }

        //Конвертирует короткую дату для БД
        public static string FlipShortDate(string date)
        {

            if (date != "")
            {

                date = date[6].ToString() +
                date[7] +
                date[8] +
                date[9] +
                '-' +
                date[3] +
                date[4] +
                '-' +
                date[0] +
                date[1];
            }
            else
            {
                date = "";
            }

            return date;
        }

        //Получает Имя из ФИО
        public static string GetNameFromFIO(string fio)
        {
            MatchCollection collection = Regex.Matches(fio, @"[A-ZА-Я][a-zа-я]*(\s|$)");

            return collection[1].Value;
        }
    }
}
