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
             .ForMember(dest => dest.TransactionIds, opt => opt.MapFrom(src => src.Transactions.Select(t => t.Id)))
             .ForMember(dest => dest.WalletIds, opt => opt.MapFrom(src => src.wallets.Select(w => w.Id)));

            CreateMap<CurencyModel, Curency>()//sxva velebi avtomaturad gadaimapeba
                .ForMember(dest => dest.Transactions, opt => opt.Ignore())
                .ForMember(dest => dest.wallets, opt => opt.Ignore());

            CreateMap<Transaction, TransactionModel>().
                ReverseMap();

            CreateMap<Wallet, WalletModel>()
            .ForMember(dest => dest.TransactionIds, opt => opt.MapFrom(src => src.Transactions.Select(t => t.Id)));

            CreateMap<WalletModel, Wallet>()
                .ForMember(dest => dest.Transactions, opt => opt.Ignore());

            CreateMap<User, UserModel>()
           .ForMember(dest => dest.Password, opt => opt.Ignore());

            CreateMap<UserModel, User>()
                .ForMember(dest => dest.PasswordHash, opt => opt.Ignore());
        }
    }
}
