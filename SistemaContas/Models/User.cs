﻿using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SistemaContas.Models
{
    public class User
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Nome Obrigatório")]
        [StringLength(15, MinimumLength = 3, ErrorMessage = "Nome deve está em {2} e {1} letras")]
        public string? Name { get; set; }
        [Required(ErrorMessage = "Sobrenome Obrigatório")]
        [StringLength(15, MinimumLength = 3, ErrorMessage = "Sobrenome deve está em {2} e {1} letras")]
        public string? LastName { get; set; }
        [Required(ErrorMessage = "Email Obrigatório")]
        [EmailAddress(ErrorMessage = "Entre com email valido")]
        [DataType(DataType.EmailAddress)]
        public string? Email { get; set; }
        [Required(ErrorMessage = "Senha Obrigatório")]
        [StringLength(10, MinimumLength = 6, ErrorMessage = "Senha deve ter entre {2} entre {1} numeros.")]
        [DataType(DataType.Password)]
        public string? Password { get; set; }
        [Required(ErrorMessage = "Confirmar senha Obrigatório")]
        [StringLength(10, MinimumLength = 6, ErrorMessage = "Senha deve ter entre {2} entre {1} numeros.")]
        [DataType(DataType.Password)]
        [Compare("Password", ErrorMessage = "As senhas devem ser iguais")]
        [NotMapped]
        public string? ConfirmPassword{ get; set; }
        public IEnumerable<Reminder>? Reminders { get; set; }
        public IEnumerable<Remember>? Remembers { get; set; }
        public IEnumerable<Bills>? Bills { get; set; }
        public IEnumerable<Debts>? Debts { get; set; }
        public IEnumerable<Goal>? Goal { get; set; }
        public IEnumerable<Earning>? Earnings{ get; set; }
        public IEnumerable<Note>? Notes { get; set; }
        public IEnumerable<Note2>? Notes2 { get; set; }
        public IEnumerable<Note3>? Notes3 { get; set; }

        public User()
        {

        }

        public User(int id, string name, string lastName, string email, string password)
        {
            Id = id;
            Name = name;
            LastName = lastName;
            Email = email;
            Password = password;
        }
    }
}
