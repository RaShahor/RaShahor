﻿using Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DAL
{
    public interface IManagerDL
    {
        Task<List<FormToSigner>> getAllFormsToUserBySigner(int id);
        Task<List<FormTemplate>> getAllFormsTemplatesByUser(int id);
        Task<List<Signer>> getAllSignersByUser(int id);
        Task<List<FormToSigner>> getAllFormsToSignerByUserIdAndSignerId(int idu,int ids);
        Task newSigner(Signer signer);
    }
}