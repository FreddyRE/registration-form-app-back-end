﻿namespace RegistrationForm.Common
{
    public class Result<T>
    {
        public bool IsSuccess { get; private set; }
        public T? Data { get; private set; }
        public string Error { get; private set; }

        public static Result<T> Success(T data) => new() { IsSuccess = true, Data = data };
        public static Result<T> Failure(string err) => new() { IsSuccess = false, Error = err };
    }
}
