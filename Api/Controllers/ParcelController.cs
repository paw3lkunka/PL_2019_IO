﻿using System;
using System.Collections.Generic;
using System.Text;
using Api.Services;
using Api.Enums;
using Model.Models;
using Model.Models.Exceptions;

namespace Api.Controllers
{
    public class ParcelController
    {
        private readonly IParcelService _parcelService;

        public ParcelController(IParcelService parcelService)
        {
            _parcelService = parcelService;
        }

        public ParcelStatus GetParcelStatusById(int id)
        {
            ParcelStatus status = ParcelStatus.Unknown;
            try
            {
                Parcel postedParcel = _parcelService.GetById(id);
                status = ParcelStatus.Posted;
                try
                {
                    Parcel returnedParcel = _parcelService.GetByReferenceId(id);
                    status = ParcelStatus.Returned;
                }
                catch (ParcelNotFoundInDatabaseException e)
                {
                    Console.WriteLine(e.Message);
                }
                if (postedParcel.IsDelivered)
                {
                    status = ParcelStatus.Delivered;
                }
            }
            catch (ParcelNotFoundInDatabaseException e)
            {
                Console.WriteLine(e.Message);
            }

            return status;
        }

        public bool PostParcel(StorePlace storePlace, PersonalData senderData, PersonalData receiverData, float height, float length, float width, string type)
        {
            var parcel = new Parcel
            {
                StorePlaceId = storePlace.Id,
                SenderData = senderData,
                ReceiverData = receiverData,
                ParcelHeight = height,
                ParcelWidth = width,
                ParcelLength = length,
                ReferenceId = 0,
                IsDelivered = false
            };
            try
            {
                _parcelService.PostParcel(parcel);
            }
            catch(NothingAddedToDatabaseException e)
            {
                Console.WriteLine(e.ToString());
                return false;
            }
            return true;
        }

        public bool DeliverParcel(int id)
        {
            try
            {
                _parcelService.DeliverParcel(_parcelService.GetById(id));
            }
            catch (ParcelNotFoundInDatabaseException e)
            {
                Console.WriteLine(e.ToString());
                return false;
            }
            catch (NothingAddedToDatabaseException e)
            {
                Console.WriteLine(e.ToString());
                return false;
            }
            return true;
        }

        public bool ReturnParcel(int id)
        {
            try
            {
                _parcelService.ReturnParcel(_parcelService.GetById(id));
            }
            catch (ParcelNotFoundInDatabaseException e)
            {
                Console.WriteLine(e.ToString());
                return false;
            }
            catch (NothingAddedToDatabaseException e)
            {
                Console.WriteLine(e.ToString());
                return false;
            }
            return true;
        }
    }
}