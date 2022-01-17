﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using DTO;
using DAL;
using Entities;

namespace BL
{
    class ManagerBL : IManagerBL

    {
        IManagerDL managerDL;
        IMapper map;
        public ManagerBL(IManagerDL mangerDL,IMapper mapper)
        {
            this.managerDL = managerDL;
            map = mapper;
        }

        public Task NewSigner(SignerDTO signerDTO)
        {
            return managerDL.newSigner(map.Map<SignerDTO,Signer>(signerDTO)) ;
        }
    }
}

