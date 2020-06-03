IF NOT EXISTS (SELECT 1 FROM sysObjects  WHERE Id=OBJECT_ID(N'[dbo].[Stocks]') and xtype='U')
BEGIN
CREATE TABLE Stocks
(
Id int primary key identity(1,1) not null,
Code varchar(16) not null,
Name nvarchar(128) not null,
DataDate varchar(16) not null, --����
OpeningPrice decimal(8,2) not null, --���̼�
ClosingPrice  decimal(8,2) not null, --���̼�
HighestPrice decimal(8,2) not null,
LowestPrice decimal(8,2) not null,
PreClosingPrice  decimal(8,2) not null,  --ǰ����
BalancePrice decimal(8,2) not null,  --�ǵ���
BalanceRange decimal(8,4) not null, --�ǵ���
TurnoverRate decimal(8,4) not null, --������
Volume int not null,--�ɽ���
TurnoverAmount Bigint not null,--�ɽ����
TotalMarketCapitalisation decimal(16,2) not null,--����ֵ
FreeFloatMarketCapitalisation  decimal(16,2) not null --��ͨ��ֵ
) ON [PRIMARY]
END
