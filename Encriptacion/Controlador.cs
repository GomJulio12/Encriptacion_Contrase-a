using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace Encriptacion
{
    class Controlador
    {

        private Dictionary<string, string> encryptionDictionary = new Dictionary<string, string>();
        private Dictionary<string, string> decryptionDictionary = new Dictionary<string, string>();

        //CREAMOS UNA METODO DONDE VAN TODOS LOS DICCIONARIO DE CADA LETRA A ENCRIPTAR
        public Controlador()
        {
            // Definir el mapeo de caracteres para encriptar y desencriptar
            encryptionDictionary.Add("A", "YC");
            encryptionDictionary.Add("B", "ZD");
            encryptionDictionary.Add("C", "AC");
            encryptionDictionary.Add("D", "BF");
            encryptionDictionary.Add("E", "CG");
            encryptionDictionary.Add("F", "DH");
            encryptionDictionary.Add("G", "EI");
            encryptionDictionary.Add("H", "FJ");
            encryptionDictionary.Add("I", "GK");
            encryptionDictionary.Add("J", "HL");
            encryptionDictionary.Add("K", "IM");
            encryptionDictionary.Add("L", "JN");
            encryptionDictionary.Add("M", "KÑ");
            encryptionDictionary.Add("N", "LO");
            encryptionDictionary.Add("Ñ", "MP");
            encryptionDictionary.Add("O", "NQ");
            encryptionDictionary.Add("P", "ÑR");
            encryptionDictionary.Add("Q", "OS");
            encryptionDictionary.Add("R", "PT");
            encryptionDictionary.Add("S", "QU");
            encryptionDictionary.Add("T", "RV");
            encryptionDictionary.Add("U", "SW");
            encryptionDictionary.Add("V", "TX");
            encryptionDictionary.Add("W", "UY");
            encryptionDictionary.Add("X", "VZ");
            encryptionDictionary.Add("Y", "WA");
            encryptionDictionary.Add("Z", "XB");


            encryptionDictionary.Add("1", "93");
            encryptionDictionary.Add("2", "04");
            encryptionDictionary.Add("3", "15");
            encryptionDictionary.Add("4", "26");
            encryptionDictionary.Add("5", "37");
            encryptionDictionary.Add("6", "48");
            encryptionDictionary.Add("7", "59");
            encryptionDictionary.Add("8", "60");
            encryptionDictionary.Add("9", "71");
            encryptionDictionary.Add("0", "82");

            //ESTE HACE EL TEXTO ENCRIPTADO LO VUELVA AL TEXTO ORIGINAL INVIRTIENDO EL DICCIONARIO.
            foreach (var entry in encryptionDictionary)
            {
                decryptionDictionary.Add(entry.Value, entry.Key);
            }
        }

        public string controladorRegistro(Usuarios usuario)
        {
            Modelo modelo = new Modelo();
            string respuesta = "";

            //PARA VALIDAR QUE TODOS LOS CAMPOS DEL FORM ESTEN LLENOS
            if (string.IsNullOrEmpty(usuario.Nombre) ||
                string.IsNullOrEmpty(usuario.Usuario) ||
                string.IsNullOrEmpty(usuario.Password) ||
                string.IsNullOrEmpty(usuario.Conpassword))
            {
                respuesta = "¡Por favor! Llena todos los campos";
            }
            else
            {
                if(usuario.Password == usuario.Conpassword)
                {
                    if (modelo.existeUsuario(usuario.Usuario))
                    {
                        respuesta = "El usuario ya existe";
                    }
                    else //CONVERSION DE CONTRASEÑA (ENCRIPTACION)
                    {
                       usuario.Password = Encriptacion(usuario.Password);
                        modelo.registro(usuario);
                    }
                }
                else
                {
                    respuesta = "Las contraseña no coincide";
                }
            }
            return respuesta;
        }

        //METODO DONDE HACE LA ENCRIPTACION
        public string Encriptacion(string cadena)
        {
            string EncriptarTexto = "";
            foreach (char character in cadena)
            {
                string charKey = character.ToString();
                if (encryptionDictionary.ContainsKey(charKey))
                {
                    EncriptarTexto += encryptionDictionary[charKey];
                }
                else
                {
                    EncriptarTexto += charKey; //MANTIENE LOS CARACTERES NO ENCRIPTADAS
                }
            }
            return EncriptarTexto;
        }

        //METODO PARA DESINCRPTAR LA CONTRASEÑA INGRESADO
        public string Descriptar(string cadena)
        {
            string TextoDescriptado = "";
            for (int i = 0; i < cadena.Length; i += 2)
            {
                string charKey = cadena.Substring(i, 2);
                if (decryptionDictionary.ContainsKey(charKey))
                {
                    TextoDescriptado += decryptionDictionary[charKey];
                }
                else
                {
                    TextoDescriptado += charKey; //MANTIENE LOS CARACTERES NO ENCRIPTADAS
                }
            }
            return TextoDescriptado;

        }


    }
}
