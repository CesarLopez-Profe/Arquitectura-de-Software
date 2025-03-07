// See https://aka.ms/new-console-template for more information
//Console.WriteLine("Hello, World!");
using p_EstrProxy.Interfaces;
using p_EstrProxy.Clases;

IBanco cajero = new ProxyBanco();
cajero.RetirarDinero("Juan", 500);  // Permitido
cajero.RetirarDinero("Pedro", 300); // Denegado
