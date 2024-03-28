using AutoMapper;
using TERA.Ca.OnlineBank.Domain.Models;
using TERA.CA.OnlineBank.Core.Entities;

namespace TERA.Ca.OnlineBank.Domain
{
    public class AutoMapperProfile:Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<Curency, CurencyModel>()
                .ForMember(des => des.Name, opt => opt.MapFrom(sr => sr.Name)).
                ForMember(des => des.Equvalent, opt => opt.MapFrom(sr => sr.Equvalent))
                .ReverseMap();

            CreateMap<Transaction, TransactionModel>().
                ForMember(des=>des.Amount,opt=>opt.MapFrom(sr=>sr.Amount)).
                 ForMember(des => des.Date, opt => opt.MapFrom(sr => sr.Date)).
                  ForMember(des => des.RecieverId, opt => opt.MapFrom(sr => sr.ReceiverWalletId)).
                   ForMember(des => des.SenderId, opt => opt.MapFrom(sr => sr.SenderId)).
                   ForMember(des => des.CurencyId, opt => opt.MapFrom(sr => sr.Wallet.CurrencyId)).
                   ForMember(des => des.TypeId, opt => opt.MapFrom(sr => sr.TypeId)).
                 ReverseMap();

            CreateMap<Wallet, WalletModel>()
            .ForMember(dest => dest.Amount, opt => opt.MapFrom(src => src.Amount))
            .ForMember(dest=>dest.CurencyId,opt=>opt.MapFrom(io=>io.CurrencyId))
            .ForMember(dest => dest.UserId, opt => opt.MapFrom(io => io.UserId))
            .ReverseMap();

            CreateMap<User, UserModel>().
           ForMember(dest => dest.Password, opt => opt.Ignore()).
           ForMember(des => des.Name, opt => opt.MapFrom(io => io.Name)).
           ForMember(des => des.Surname, opt => opt.MapFrom(io => io.Surname)).
           ForMember(des => des.Username, opt => opt.MapFrom(io => io.UserName)).
           ForMember(des => des.Email, opt => opt.MapFrom(io => io.Email)).
           ForMember(des => des.PersonalNumber, opt => opt.MapFrom(io => io.PersonalNumber))
             .ReverseMap();

            CreateMap<TransactionType, TransactionTypeModel>().
                 ForMember(dest => dest.TransactionName, opt => opt.MapFrom(io => io.TransactionName))
                 .ReverseMap();

        }
    }
}
