// See https://aka.ms/new-console-template for more information
//Console.WriteLine("Hello, World!");
using p_est_decorator.Interfaces;
using p_est_decorator.Clases;

IAuto auto = new Auto();
Console.WriteLine($"{auto.ObtenerDescripcion()} cuesta ${auto.ObtenerCosto()}");

auto = new GPS(auto);
Console.WriteLine($"{auto.ObtenerDescripcion()} cuesta ${auto.ObtenerCosto()}");

auto = new SillaCuero(auto);
Console.WriteLine($"{auto.ObtenerDescripcion()} cuesta ${auto.ObtenerCosto()}");

auto = new SonidoBose(auto);
Console.WriteLine($"{auto.ObtenerDescripcion()} cuesta ${auto.ObtenerCosto()}");
