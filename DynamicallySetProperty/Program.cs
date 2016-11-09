using ModelosCompartilhados;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Reflection;

namespace PropriedadesDinamicamente
{
    class Program
    {
        static void Main(string[] args)
        {
            // O teste abaixo não funcionou, funcionaria com javascript
            //string marca = "Marca";
            //string modelo = "Modelo";
            //string placa = "Placa";

            //Carro c2 = new Carro();
            //c2[marca] = "Ford";
            //c2[modelo] = "Fox";
            //c2[placa] = "ABC1234";

            List<Hashtable> listHash = new List<Hashtable>();
            Hashtable hashTable1 = new Hashtable();
            hashTable1.Add("Marca", "Ford");
            hashTable1.Add("Modelo", "Fox");
            hashTable1.Add("Placa", "ABC1234");
            listHash.Add(hashTable1);

            Hashtable hashTable2 = new Hashtable();
            hashTable2.Add("Marca", "Hyundai");
            hashTable2.Add("Modelo", "HB20");
            hashTable2.Add("Placa", "DEF4567");
            listHash.Add(hashTable2);

            List<Carro> listCarro = new List<Carro>();
            foreach (var hash in listHash)
            {
                Carro carro = new Carro();
                foreach (var key in hash.Keys)
                {
                    PropertyInfo prop = carro.GetType().GetProperty(key.ToString());
                    if (prop != null && prop.CanWrite)
                    {
                        prop.SetValue(carro, hash[key], null);
                    }
                }
                listCarro.Add(carro);
            }
            int cont = 0;
            foreach (var carro in listCarro)
            {
                cont++;
                Console.WriteLine($"Carro {cont} \nMarca do carro: {carro.Marca}, modelo do carro: {carro.Modelo}, placa do carro: {carro.Placa}");
            }
            Console.ReadKey();
            //myObject.GetType().GetProperty(property).SetValue(myObject, "Bob", null);

        }
    }
}
