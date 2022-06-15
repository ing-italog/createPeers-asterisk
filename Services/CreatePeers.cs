using CreatePeers.Models;
using System;
using System.Configuration;
using System.IO;


namespace CreatePeers.Services
{
    /**
     * [Aquí se encuentra toda la lógica de la App, el paso de creación es :
     *   1. Crea el folder, en la ruta especificada en el App.config, si el folder existe omite este paso.
     *   2. Solicita el nombre del documento.
     *   3. Solicita el contexto de los peers
     *   4. Solicita desde que extensión hasta que extensión se crearan los peers
     *   5. Crea el documento en la carpeta y con el nombre asignado]
     *   
     *   @Version 05-Jun-2022 , 1.0.0.0
     */
    public class CreatePeers
    {        
        private static string folderPath = ConfigurationManager.AppSettings["Path_folder"];

        /**
         * [Crea primero el folder y despues crea el documento]
         * 
         * @Exception [cuando ocurre un error en la ubicación del documento y/o otros]
         */
        public void created()
        {
            createFolder();

            string nameDocumento = getNameDocument() + ".conf";

            string documentPath = ConfigurationManager.AppSettings["Path_folder"] + "\\" + nameDocumento;

            string context = getContext();

            NumbersPeer numbersPeer = getNumberPeers();            

            try
            {                     
                using (System.IO.StreamWriter file = new System.IO.StreamWriter(documentPath))
                {

                    for (int i = 0; i <= (numbersPeer.until - numbersPeer.from); i++)
                    {
                        file.WriteLine("[" + (numbersPeer.from + i) + "]"
                                      + "\nusername=" + (numbersPeer.until + i + 1)
                                      + "\ntype=friend"
                                      + "\nsecret=Qa$12Pl9&0"
                                      + "\nqualify=no"
                                      + "\nport=5060"
                                      + "\npickupgroup="
                                      + "\nnat=yes"
                                      + "\nmailbox="
                                      + "\nhost=dynamic"
                                      + "\ndtmfmode=rtfc2833"
                                      + "\ncontext=" + context
                                      + "\ncanreinvite=0"
                                      + "\ncallgroup="
                                      + "\ncallerid=" + (numbersPeer.until + i + 1)
                                      + "\nrecord=no\n\n");
                    }
                }

                Console.WriteLine("\n\n[SUCCESS] - creados " + (numbersPeer.until - numbersPeer.from) + " Peers - documento {" + documentPath + "}");

                //Congela la ejecución durante 30 segundos
                System.Threading.Thread.Sleep(300000);

            }
            catch (Exception ex)
            {
                Console.WriteLine("[ERROR] " + ex.Message);
                System.Threading.Thread.Sleep(300000);
            }
        }

        /**
         * [Obtiene el nombre que se le asignara al documento, válida que el número del documento sea mayor a 3 caracteres]
         * 
         * @Return nombreDocument STRING
         */
        private string getNameDocument()
        {
            string nameDocument;

            Console.Write("Escribe el nombre del documento = ");
            nameDocument = Console.ReadLine();

            while ((nameDocument == "") || (nameDocument.Length <= 3))
            {
                logError("Por favor ingresa un nombre mayor a 4 caracteres");

                Console.Write("Escribe el nombre del documento = ");
                nameDocument = Console.ReadLine();
            }

            return nameDocument;
        }

        /**
         *[Obtiene el contexto que se usara 
         */
        private string getContext()
        {
            string context;

            Console.Write("Escribe el nombre contexto = ");
            context = Console.ReadLine();

            while ((context == "") || (context.Length <= 3))
            {
                logError("Por favor ingresa un contexto mayor a 4 caracteres");

                Console.Write("Escribe el nombre del context = ");
                context = Console.ReadLine();
            }

            return context;
        }


        /**
         * [Obtiene el numero de peers que desea el usuario, si el numero hasta es mayor al numero desde, seguira solicitando un número válido, si desea cancelar 
         *  la operación se escribe el número 0]
         *  
         *  @Return NumbersPeer OBJECT
         */
        private NumbersPeer getNumberPeers()
        {
            NumbersPeer numPeers = new NumbersPeer(0, 0);

            while (numPeers.from < 2)
            {
                try
                {
                    Console.Write("Desde = ");
                    numPeers.from = Convert.ToInt32(Console.ReadLine());
                }
                catch
                {
                    logError("opción inválida");
                    numPeers.from = -1;
                }
            }

            while (numPeers.until < numPeers.from)
            {
                try
                {
                    Console.Write("HASTA = ");
                    numPeers.until = Convert.ToInt32(Console.ReadLine());
                }
                catch
                {
                    logError("opción inválida");
                    numPeers.until = -1;
                }

                if (numPeers.until < numPeers.from)
                {
                    logError("Numero no válido");
                }
            }

            return numPeers;
        }

        /**
        * [Crea el directorio y retorna la dirección donde fue creado]
        * 
        * @Return pathDirectorio STRING
        */
        private void createFolder()
        {

            if (!Directory.Exists(folderPath))
            {
                Directory.CreateDirectory(folderPath);
                Console.WriteLine("Se creo el directorio donde se guardara el archivo la ruta es = " + folderPath);
            }
        }

        /**
         * [Imprime por consola los errores que puedan ocurrir durante la operación]
         */
        private void logError(string error)
        {
            Console.WriteLine("[ERROR] - " + error);
        }
    }
}
