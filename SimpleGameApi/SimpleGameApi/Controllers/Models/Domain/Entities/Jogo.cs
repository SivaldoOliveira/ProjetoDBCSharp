﻿namespace SimpleGameApi.Controllers.Models.Domain.Entities;

public class Jogo
{
    public int Id { get; set; }
    public string Nome { get; set; }
    public string Plataforma {  get; set; }
    public string Genero { get; set; }
    public Decimal Preco { get; set; }
    public DateTime DataLancamento { get; set; }
}
