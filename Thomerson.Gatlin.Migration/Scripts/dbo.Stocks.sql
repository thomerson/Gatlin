IF NOT EXISTS (SELECT 1 FROM sysObjects  WHERE Id=OBJECT_ID(N'[dbo].[Stocks]') and xtype='U')
BEGIN
CREATE TABLE Stocks
(
Id int primary key identity(1,1) not null,
Code varchar(16) not null,
Name nvarchar(128) not null,
DataDate varchar(16) not null, --日期
OpeningPrice decimal(8,2) not null, --开盘价
ClosingPrice  decimal(8,2) not null, --收盘价
HighestPrice decimal(8,2) not null,
LowestPrice decimal(8,2) not null,
PreClosingPrice  decimal(8,2) not null,  --前收盘
BalancePrice decimal(8,2) not null,  --涨跌额
BalanceRange decimal(8,4) not null, --涨跌幅
TurnoverRate decimal(8,4) not null, --换手率
Volume int not null,--成交量
TurnoverAmount Bigint not null,--成交金额
TotalMarketCapitalisation decimal(16,2) not null,--总市值
FreeFloatMarketCapitalisation  decimal(16,2) not null --流通市值
) ON [PRIMARY]
END
