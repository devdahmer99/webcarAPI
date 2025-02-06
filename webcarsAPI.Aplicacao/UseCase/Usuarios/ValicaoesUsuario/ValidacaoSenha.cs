﻿using System.Text.RegularExpressions;
using FluentValidation;
using FluentValidation.Validators;
using webcarsAPI.Exception;

namespace webcarsAPI.Aplicacao.UseCase.Usuarios.ValicaoesUsuario
{
    public class ValidacaoSenha<T> : PropertyValidator<T, string>
    {
        private const string MENSAGEM_ERRO = "MensagemErro";
        public override string Name => "ValidacaoSenha";
        protected override string GetDefaultMessageTemplate(string errorCode)
        {
            return $"{{{MENSAGEM_ERRO}}}";
        }

        public override bool IsValid(ValidationContext<T> context, string senha)
        {
            if (string.IsNullOrWhiteSpace(senha))
            {
                context.MessageFormatter.AppendArgument(MENSAGEM_ERRO, ResourceErrorMessages.SENHA_INVALIDA);
                return false;
            }

            if (senha.Length < 8)
            {
                context.MessageFormatter.AppendArgument(MENSAGEM_ERRO, ResourceErrorMessages.SENHA_INVALIDA);
                return false;
            }

            if (Regex.IsMatch(senha, pattern: @"[A-Z]+") == false)
            {
                context.MessageFormatter.AppendArgument(MENSAGEM_ERRO, ResourceErrorMessages.SENHA_INVALIDA);
                return false;
            }

            if (Regex.IsMatch(senha, pattern: @"[a-z]+") == false)
            {
                context.MessageFormatter.AppendArgument(MENSAGEM_ERRO, ResourceErrorMessages.SENHA_INVALIDA);
                return false;
            }

            if (Regex.IsMatch(senha, pattern: @"[0-9]+") == false)
            {
                context.MessageFormatter.AppendArgument(MENSAGEM_ERRO, ResourceErrorMessages.SENHA_INVALIDA);
                return false;
            }

            if (Regex.IsMatch(senha, pattern: @"[\!\?\*\.]+") == false)
            {
                context.MessageFormatter.AppendArgument(MENSAGEM_ERRO, ResourceErrorMessages.SENHA_INVALIDA);
                return false;
            }

            return true;
        }
    }
}
