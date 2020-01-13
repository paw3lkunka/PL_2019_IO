﻿using System;
using System.Collections.Generic;
using System.Text;
using Api.Managers;
using Model.Models;

namespace Api.Services
{
    public interface IPositionService
    {
        public List<Position> GetAllPosition();
        public Position GetPositionByID(int positionID);

        public void RemovePosition(Position position);

        public void AddPosition(Position position);

        public void UpdatePosition(Position position);
    }
}
