using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Football.Models.Enums
{
    public static class EnumMapper
    {
        public static Dictionary<string, CountryEnum> CountryMap = new Dictionary<string, CountryEnum>()
        {
             {"Россия", CountryEnum.Russia},
             {"США", CountryEnum.USA},
             {"Италия", CountryEnum.Italy},
             {"Russia", CountryEnum.Russia},
             {"USA", CountryEnum.USA},
             {"Italy", CountryEnum.Italy}
        };
        public static Dictionary<string, GenderEnum> GenderMap = new Dictionary<string, GenderEnum>()
        {
             {"Мужской", GenderEnum.Male},
             {"Женский", GenderEnum.Female},
             {"Male", GenderEnum.Male},
             {"Female", GenderEnum.Female},
        };

        public static CountryEnum ToCountryEnum(string input)
        {
            CountryEnum result;
            if (CountryMap.TryGetValue(input, out result))
                return result;
            else
                throw new ArgumentException("Не найдена страна с таким названием!");
        }

        public static GenderEnum ToGenderEnum(string input)
        {
            GenderEnum result;
            if (GenderMap.TryGetValue(input, out result))
                return result;
            else
                throw new ArgumentException("Не найден пол с таким названием!");
        }

        public static string CountryToString(CountryEnum input)
        {
            if (CountryMap.ContainsValue(input))
                return CountryMap
                    .First(c => c.Value == input)
                    .Key;
            else
                throw new ArgumentException("Ошибка во время парсинга CountryEnum в String!");
        }

        public static string GenderToString(GenderEnum input)
        {
            if (GenderMap.ContainsValue(input))
                return GenderMap
                    .First(c => c.Value == input)
                    .Key;
            else
                throw new ArgumentException("Ошибка во время парсинга GenderEnum в String!");
        }
    }
}
