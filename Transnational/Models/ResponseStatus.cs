using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Transnational.Models
{
    [Serializable]
    public class ResponseStatus<T>
    {
        /// <summary>
        /// It indicate the repose status of API
        /// </summary>
        public bool IsSuccess;

        /// <summary>
        /// It contains the message sent through web API
        /// </summary>
        public string Message;

        /// <summary>
        /// It is to sent response date time
        /// </summary>
        public string UpdatedDate;

        /// <summary>
        /// It is responsible to wrap the API response
        /// </summary>
        public T Result;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="success"></param>
        /// <param name="message"></param>
        /// <param name="result"></param>
        /// <param name="a"></param>
        /// <returns></returns>
        public ResponseStatus<T> Create(bool success, string message, T result, string a = "")
        {
            return new ResponseStatus<T>
            {
                IsSuccess = success,
                Message = message,
                UpdatedDate = DateTime.Now.ToString(), //Updated date
                Result = result
            };
        }

        //internal ResponseStatus<List<Contacts>> Create(bool v, string serverError, object contact)
        //{
        //    throw new NotImplementedException();
        //}


        //internal ResponseStatus<List<tblCompanyBranch>> Create(bool p1, string p2, List<Department> Department)
        //{
        //    throw new NotImplementedException();
        //}
    }
}