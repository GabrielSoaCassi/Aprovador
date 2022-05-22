using System;
using System.ComponentModel;

namespace BackEndAprovacao.Models
{
    public static class EnumHelper
    {
        public static string ObterDescricao<TEnum>(this TEnum valor) where TEnum : struct, IConvertible
        {
            if (!typeof(TEnum).IsEnum) return null;

            var descricao = valor.ToString();
            var informacao = valor.GetType().GetField(valor.ToString());

            if (informacao != null)
            {
                var atributo = informacao.GetCustomAttributes(typeof(DescriptionAttribute), true);
                if (atributo != null && atributo.Length > 0)
                {
                    descricao = ((DescriptionAttribute)atributo[0]).Description;
                }
            }
            return descricao;
        }
    }
}