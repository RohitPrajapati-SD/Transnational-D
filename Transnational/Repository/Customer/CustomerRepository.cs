using System.Configuration;
using System.Data.SqlClient;
using Transnational.Models.VM;
using Transnational.Common;
using System.Data;
using System;

namespace Transnational.Repository.Customer
{
    public class CustomerRepository
    {
       

       
        public DataSet GetCustomer(string dbParam)
        {
            DbConnections conobj = new DbConnections();
            var con = conobj.connection(dbParam);
            DataSet ds = new DataSet();
            string query = "";
            query = "Select CompanyId, CustomerName From tblCompany Order By CustomerName";
            using (SqlDataAdapter da = new SqlDataAdapter(query, con))
            {
                con.Open();
                da.Fill(ds);
                return ds;
            }
        }

        public DataSet GetDepartment(string dbParam, int ContactId, int ContractId)
        {
            DbConnections conobj = new DbConnections();
            var con = conobj.connection(dbParam);
            DataSet ds = new DataSet();
            //int ContactId = 8;
            //int CompanyId = 9;
            string query = "";
            query = "Select coalesce(BranchName,'') + coalesce('-'+ContactName,'') as BranchName ,";
            query += "tblCompanyBranch.CBranchId  from tblCompanyBranch ";
            query += " inner join tblContractCostCentre on tblCompanyBranch.CBranchId=tblContractCostCentre.CBranchId And ";
            query += " ContractId='" + ContractId + "' where tblCompanyBranch.CBranchId in ";
            query += " (Select CBranchId from tblContactCostCentre Where ContactId='" + ContactId + "')";
            query += " or tblCompanyBranch.CBranchId in (Select CBranchId from tblContacts Where ContactId='" + ContactId + "') and tblCompanyBranch.DActive='true' ";
            query += " and tblCompanyBranch.ActiveSince <= '" + DateTime.Now.ToString("MM/dd/yyyy") + "'";
            query += " order by BranchName,ContactName";
            using (SqlDataAdapter da = new SqlDataAdapter(query, con))
            {
                con.Open();
                da.Fill(ds);
                con.Close();
                return ds;

            }
        }
        public DataSet GetCustomer1(string dbParam)
        {
            DbConnections conobj = new DbConnections();
            var con = conobj.connection(dbParam);
            DataSet ds = new DataSet();
            string query = "";
            query = "Select CompanyId,NickName, CustomerName,ContactTypeId,Tel from tblCompany Order By CustomerName";
            using (SqlDataAdapter da = new SqlDataAdapter(query, con))
            {
                con.Open();
                da.Fill(ds);
                return ds;
            }
        }

        public DataSet GetCustomerById(string dbParam, int CustomerId)
        {
            DbConnections conobj = new DbConnections();
            var con = conobj.connection(dbParam);
            DataSet ds = new DataSet();
            string query = "";
            //query = "Select NickName, CustomerName, CompanyId  ,ContactTypeId,Tel,Fax, ZoneId,  CustomerGroupId  ,CustomerCategoryId,CustomerTypeId,  KeyAccountManager , EnquirySourceId, CustomerStatusId, CreatedDate , Portfolio, BusinessUnitId, CustomerId, LUDate,LUBy, LanguageId,  ActiveSince, UnFreezeSince, ICompanySales, Active,CompanyLogo,CreatedBy  , CreditAmount,  DepositAmount, ContactPerson, SendSms,SendEmail, CCenter_on_orderPage From tblCompany where CompanyId = " + CustomerId + " Order By Customerid";

            query = " Select  NickName, CustomerName, CompanyId  ,ContactTypeId,Tel,Fax, ZoneId,  CustomerGroupId  ,CustomerCategoryId,CustomerTypeId,  KeyAccountManager , EnquirySourceId, CustomerStatusId, CreatedDate , Portfolio, BusinessUnitId, CustomerId, LUDate,LUBy, LanguageId,  ActiveSince, UnFreezeSince, ICompanySales, Active,CompanyLogo,CreatedBy  , CreditAmount,  DepositAmount, ContactPerson, SendSms,SendEmail, CCenter_on_orderPage From tblCompany ";
              query += " where CompanyId  >  255 and CompanyId <266   Order By CompanyId";

            using (SqlDataAdapter da = new SqlDataAdapter(query, con))
            {
                con.Open();
                da.Fill(ds);
                return ds;

            }
        }


        public DataSet GetCustomerBySearch(string dbParam, string SearchData, int CompanyId)
        {
            DbConnections conobj = new DbConnections();
            var con = conobj.connection(dbParam);
            DataSet ds = new DataSet();
            string query = "";
            query += "select CCNo,Department,BranchName,Address1,ContactName,Email,Address1,Phone,CBranchId from tblCompanyBranch where  tblCompanyBranch.CompanyId ='" + CompanyId + "' ";

            query += "and  (tblCompanyBranch.BranchName like   '" + SearchData + "'  or tblCompanyBranch.Phone like  '" + SearchData + "'or tblCompanyBranch.Address1 like '" + SearchData + "'or tblCompanyBranch.Address2 like  '" + SearchData + "'or tblCompanyBranch.Address3 like  '" + SearchData + "'or tblCompanyBranch.Address4 like  '" + SearchData + "' ";
            query += " or tblCompanyBranch.Mobile like  '" + SearchData + "' or tblCompanyBranch.Email like  '" + SearchData + "' or tblCompanyBranch.PinCode like  '" + SearchData + "' ";
            query += " or tblCompanyBranch.Department like '" + SearchData + "' or tblCompanyBranch.ContactName like  '" + SearchData + "' or tblCompanyBranch.CCNo like  '" + SearchData + "' ";
            query += ") order by BranchName , ContactName ";
            using (SqlDataAdapter da = new SqlDataAdapter(query, con))
            {
                con.Open();
                da.Fill(ds);
                return ds;
            }
        }
        public DataSet GetCustomerBySearch1(string dbParam, string SearchData, int CompanyId)
        {
            DbConnections conobj = new DbConnections();
            var con = conobj.connection(dbParam);
            DataSet ds = new DataSet();
            string query = "";
            query += "select CCNo,Department,BranchName,Address1,ContactName,Email,Address1,Phone,CBranchId from tblCompanyBranch where  tblCompanyBranch.CompanyId ='" + CompanyId + "'";
            query += " and  (tblCompanyBranch.BranchName like  '" + SearchData + "' or tblCompanyBranch.Phone like  '" + SearchData + "' or tblCompanyBranch.Address1 like  '" + SearchData + "'or tblCompanyBranch.Address2 like  '" + SearchData + "' or tblCompanyBranch.Address3 like  '" + SearchData + "' or tblCompanyBranch.Address4 like  '" + SearchData + "'";
            query += "or tblCompanyBranch.Mobile like  '" + SearchData + "'   or tblCompanyBranch.Email like  '" + SearchData + "' or tblCompanyBranch.PinCode like   '" + SearchData + "'";
            query += "or tblCompanyBranch.Department like '" + SearchData + "'  or tblCompanyBranch.ContactName like   '" + SearchData + "' or tblCompanyBranch.CCNo like  '" + SearchData + "' ";
            query += ") order by BranchName , ContactName";


            using (SqlDataAdapter da = new SqlDataAdapter(query, con))
            {
                con.Open();
                da.Fill(ds);
                return ds;

            }
            //==========================companybranch==========================//
        }

        public DataSet GetAllCompanyBranch(string dbParam, int CBranchId)
        {
            DbConnections conobj = new DbConnections();
            var con = conobj.connection(dbParam);
            DataSet ds = new DataSet();
            //int ContactId = 8;
            //int CompanyId = 9;
            string query = "";
            query = "select ISNULL(Mobile,'') as Mobile,ISNULL(BranchName,'') as BranchName,ISNULL(CompanyId,0) as CompanyId,ISNULL(Address1,'') as Address1,ISNULL(Address2,'') as Address2,";
            query += "ISNULL(Address3,'') as Address3,ISNULL(CityId,0) as CityId,ISNULL(PinCode,'') as PinCode,ISNULL(CountryId,0) as CountryId,ISNULL(Phone,'') as Phone, ";
            query += " ISNULL(Fax,'') as Fax,ISNULL(Email,'') as Email,ISNULL(WebSite,'') as WebSite,ISNULL(BranchHead,'') as BranchHead,ISNULL(CurrencyId,0) as CurrencyId,ISNULL(Address4,'') as Address4, ";
            query += "ISNULL(NickName,'') as NickName,ISNULL(ZoneId,0) as ZoneId,ISNULL(DistrictId,0) as DistrictId,ISNULL(NewBranchId,0) as NewBranchId,ISNULL(Extension1,'') as Extension1,ISNULL(Extension2,'') as Extension2, ";
            query += " ISNULL(Mobile,'') as Mobile,ISNULL(LanguageId,0) as LanguageId,ISNULL(Billable,'') as Billable,ISNULL(CreatedDate,'') as CreatedDate,ISNULL(Createdby,'') as Createdby,";
            query += " ISNULL(LUDate,'') as LUDate,ISNULL(LUBy,'') as LUBy,ISNULL(ActiveSince,'') as ActiveSince,ISNULL(ASReason,'') as ASReason,ISNULL(UnFreezeSince,'') as UnFreezeSince, ";
            query += " ISNULL(UFReason,'') as UFReason,ISNULL(HigherLevel,'') as HigherLevel,ISNULL(CCNo,'') as CCNo,ISNULL(LevelNo,'') as LevelNo,ISNULL(ASReason,'') as ASReason,";
            query += "ISNULL(DActive,'') as DActive,ISNULL(DFreeze,'') as DFreeze,ISNULL(LoginQPin,'') as LoginQPin,ISNULL(LoginQPin,'') as LoginQPin,ISNULL(DLUByType,'') as DLUByType,";
            query += "ISNULL(ApprovalLevel1,'') as ApprovalLevel1,ISNULL(ApprovalLevel2,'') as ApprovalLevel2,ISNULL(ApprovalLevel3,'') as ApprovalLevel3,ISNULL(DCreatedByType,'') as DCreatedByType,ISNULL(ContactName,'') as ContactName,";
            query += "ISNULL(Department,'') as Department,ISNULL(Regionid,'') as Regionid,ISNULL(Stateid,'') as Stateid,ISNULL(Delivery,'') as Delivery,ISNULL(Collection,'') as Collection,ISNULL(BLatitude,'') as BLatitude,";
            query += "ISNULL(BLongitude,'') as BLongitude from tblCompanyBranch";
            using (SqlDataAdapter da = new SqlDataAdapter(query, con))
            {
                con.Open();
                da.Fill(ds);
                con.Close();
                return ds;

            }
        }
        //====================================CompanyAddressBook==========================================

        public DataSet DContactAddress(string dbParam, int ContactId, int Delivery, int CustomerId)
        {
            DbConnections conobj = new DbConnections();
            var con = conobj.connection(dbParam);
            DataSet ds = new DataSet();
            //int ContactId = 8;
            //int CompanyId = 9;
            string query = "";
            query = "Select ISNULL(BranchName,'') as BranchName,ISNULL(CostCenterName,'') as CostCenterName,ISNULL(ContactName,'') as ContactName,ISNULL(Department,'') as Department,";
            query += "ISNULL(Address1,'') as Address1,ISNULL(ContactNumber1,'') as ContactNumber1 from tblCompanyAddressBook A inner join tblCompanyContactAddress B on A.CABID=B.AddressBookId where B.ContactId= '" + ContactId + "' And B.Delivery='" + Delivery + "' And A.CustomerId='" + CustomerId + "'";
            //  query += " ISNULL(Fax,'') as Fax,ISNULL(Email,'') as Email,ISNULL(WebSite,'') as WebSite,ISNULL(BranchHead,'') as BranchHead,ISNULL(CurrencyId,0) as CurrencyId,ISNULL(Address4,'') as Address4, ";
            // query += "ISNULL(NickName,'') as NickName,ISNULL(ZoneId,0) as ZoneId,ISNULL(DistrictId,0) as DistrictId,ISNULL(NewBranchId,0) as NewBranchId,ISNULL(Extension1,'') as Extension1,ISNULL(Extension2,'') as Extension2, ";
            // query += " ISNULL(Mobile,'') as Mobile,ISNULL(LanguageId,0) as LanguageId,ISNULL(Billable,'') as Billable,ISNULL(CreatedDate,'') as CreatedDate,ISNULL(Createdby,'') as Createdby,";
            // query += " ISNULL(LUDate,'') as LUDate,ISNULL(LUBy,'') as LUBy,ISNULL(ActiveSince,'') as ActiveSince,ISNULL(ASReason,'') as ASReason,ISNULL(UnFreezeSince,'') as UnFreezeSince, ";
            // query += " ISNULL(UFReason,'') as UFReason,ISNULL(HigherLevel,'') as HigherLevel,ISNULL(CCNo,'') as CCNo,ISNULL(LevelNo,'') as LevelNo,ISNULL(ASReason,'') as ASReason,";
            // query += "ISNULL(DActive,'') as DActive,ISNULL(DFreeze,'') as DFreeze,ISNULL(LoginQPin,'') as LoginQPin,ISNULL(LoginQPin,'') as LoginQPin,ISNULL(DLUByType,'') as DLUByType,";
            // query += "ISNULL(ApprovalLevel1,'') as ApprovalLevel1,ISNULL(ApprovalLevel2,'') as ApprovalLevel2,ISNULL(ApprovalLevel3,'') as ApprovalLevel3,ISNULL(DCreatedByType,'') as DCreatedByType,ISNULL(ContactName,'') as ContactName,";
            // query += "ISNULL(Department,'') as Department,ISNULL(Regionid,'') as Regionid,ISNULL(Stateid,'') as Stateid,ISNULL(Delivery,'') as Delivery,ISNULL(Collection,'') as Collection,ISNULL(BLatitude,'') as BLatitude,";
            // query += "ISNULL(BLongitude,'') as BLongitude from tblCompanyBranch";
            using (SqlDataAdapter da = new SqlDataAdapter(query, con))
            {
                con.Open();
                da.Fill(ds);
                con.Close();
                return ds;

            }
        }
        //=================================================================================



        public DataSet GetCContactAddress(string dbParam, int ContactId, int Collection, int CustomerId)
        {
            DbConnections conobj = new DbConnections();
            var con = conobj.connection(dbParam);
            DataSet ds = new DataSet();
            //int ContactId = 8;
            //int CompanyId = 9;
            string query = "";
            query = "Select ISNULL(BranchName,'') as BranchName,ISNULL(CostCenterName,'') as CostCenterName,ISNULL(ContactName,'') as ContactName,ISNULL(Department,'') as Department,";
            query += "ISNULL(Address1,'') as Address1, ISNULL(Address1,'') as Address1 from tblCompanyAddressBook A inner join tblCompanyContactAddress B on A.CABID=B.AddressBookId where B.ContactId='" + ContactId + "' And B.Collection='" + Collection + "' And A.CustomerId='" + CustomerId + "'";
            //  query += " ISNULL(Fax,'') as Fax,ISNULL(Email,'') as Email,ISNULL(WebSite,'') as WebSite,ISNULL(BranchHead,'') as BranchHead,ISNULL(CurrencyId,0) as CurrencyId,ISNULL(Address4,'') as Address4, ";
            // query += "ISNULL(NickName,'') as NickName,ISNULL(ZoneId,0) as ZoneId,ISNULL(DistrictId,0) as DistrictId,ISNULL(NewBranchId,0) as NewBranchId,ISNULL(Extension1,'') as Extension1,ISNULL(Extension2,'') as Extension2, ";
            // query += " ISNULL(Mobile,'') as Mobile,ISNULL(LanguageId,0) as LanguageId,ISNULL(Billable,'') as Billable,ISNULL(CreatedDate,'') as CreatedDate,ISNULL(Createdby,'') as Createdby,";
            // query += " ISNULL(LUDate,'') as LUDate,ISNULL(LUBy,'') as LUBy,ISNULL(ActiveSince,'') as ActiveSince,ISNULL(ASReason,'') as ASReason,ISNULL(UnFreezeSince,'') as UnFreezeSince, ";
            // query += " ISNULL(UFReason,'') as UFReason,ISNULL(HigherLevel,'') as HigherLevel,ISNULL(CCNo,'') as CCNo,ISNULL(LevelNo,'') as LevelNo,ISNULL(ASReason,'') as ASReason,";
            // query += "ISNULL(DActive,'') as DActive,ISNULL(DFreeze,'') as DFreeze,ISNULL(LoginQPin,'') as LoginQPin,ISNULL(LoginQPin,'') as LoginQPin,ISNULL(DLUByType,'') as DLUByType,";
            // query += "ISNULL(ApprovalLevel1,'') as ApprovalLevel1,ISNULL(ApprovalLevel2,'') as ApprovalLevel2,ISNULL(ApprovalLevel3,'') as ApprovalLevel3,ISNULL(DCreatedByType,'') as DCreatedByType,ISNULL(ContactName,'') as ContactName,";
            // query += "ISNULL(Department,'') as Department,ISNULL(Regionid,'') as Regionid,ISNULL(Stateid,'') as Stateid,ISNULL(Delivery,'') as Delivery,ISNULL(Collection,'') as Collection,ISNULL(BLatitude,'') as BLatitude,";
            // query += "ISNULL(BLongitude,'') as BLongitude from tblCompanyBranch";
            using (SqlDataAdapter da = new SqlDataAdapter(query, con))
            {
                con.Open();
                da.Fill(ds);
                con.Close();
                return ds;

            }
        }
        public DataSet GetCollectionAddress(string dbParam, int ContactId, string FAddress)
        {
            DbConnections conobj = new DbConnections();
            var con = conobj.connection(dbParam);
            DataSet ds = new DataSet();
            //int ContactId = 8;
            //int CompanyId = 9;
            string query = "";
            query = "Select Count(*) as Count from tblContacts where ContactId='" + ContactId + "' And FAddress='" + FAddress + "'";
            using (SqlDataAdapter da = new SqlDataAdapter(query, con))
            {
                con.Open();
                da.Fill(ds);
                con.Close();
                return ds;

            }
        }
        public DataSet GetCompanyAddressBook(string dbParam, int ContactId, int CustomerId)
        {
            DbConnections conobj = new DbConnections();
            var con = conobj.connection(dbParam);
            DataSet ds = new DataSet();
            //int ContactId = 8;
            //int CompanyId = 9;
            string query = "";
            //query = "Select Count(*) as Count from tblContacts where ContactId='" + ContactId + "' And FAddress='" + FAddress + "'";
            query = "Select Count(*) as Count  from tblCompanyAddressBook A inner join tblCompanyContactAddress B on A.CABID=B.AddressBookId where B.ContactId='" + ContactId + "'And B.Collection=1 And A.CustomerId='" + CustomerId + "'";
            using (SqlDataAdapter da = new SqlDataAdapter(query, con))
            {
                con.Open();
                da.Fill(ds);
                con.Close();
                return ds;

            }
        }
        public DataSet GetContacts(string dbParam, int ContactId)
        {
            DbConnections conobj = new DbConnections();
            var con = conobj.connection(dbParam);
            DataSet ds = new DataSet();
            //int ContactId = 8;
            //int CompanyId = 9;
            string query = "";
            //query = "Select Count(*) as Count from tblContacts where ContactId='" + ContactId + "' And FAddress='" + FAddress + "'";
            //query = "Select Count(*) as Count  from tblCompanyAddressBook A inner join tblCompanyContactAddress B on A.CABID=B.AddressBookId where B.ContactId='" + ContactId + "'And B.Collection=1 And A.CustomerId='" + CustomerId + "'";
            query = "select CN.*, isnull(CN.FirstName,'')+ ' '+isnull(CN.MiddleName,'')+ ' '+ isnull(CN.LastName,'') as contactName , CMB.BranchName as BranchName , CMB.Department as Department from tblContacts CN,tblCompanyBranch CMB where CN.CBranchId= CMB.CBranchId and CN.ContactId ='" + ContactId + "'";
            using (SqlDataAdapter da = new SqlDataAdapter(query, con))
            {
                con.Open();
                da.Fill(ds);
                con.Close();
                return ds;

            }

        }
        public DataSet GetCompanyAddressBookId(string dbParam, int ContactId, int CustomerId)
        {
            DbConnections conobj = new DbConnections();
            var con = conobj.connection(dbParam);
            DataSet ds = new DataSet();
            //int ContactId = 8;
            //int CompanyId = 9;
            string query = "";
            //query = "Select Count(*) as Count from tblContacts where ContactId='" + ContactId + "' And FAddress='" + FAddress + "'";
            //query = "Select Count(*) as Count  from tblCompanyAddressBook A inner join tblCompanyContactAddress B on A.CABID=B.AddressBookId where B.ContactId='" + ContactId + "'And B.Collection=1 And A.CustomerId='" + CustomerId + "'";
            query = "Select ContactNumber1 As Tel,ContactNumber2 as Phone2,Ext1 as Extension1,Ext2 As Extension2,CostCenterName As BranchName,contactName,CountryId,CityId,DistrictId,ZoneId,PostalCode As PinCode,Address1 as Address,Address2,Address3,Address4,Coalesce(Department,' ') As Department from tblCompanyAddressBook A inner join tblCompanyContactAddress B on A.CABID=B.AddressBookId where B.ContactId='" + ContactId + "' And B.Collection=1 And A.CustomerId='" + CustomerId + "'";
            using (SqlDataAdapter da = new SqlDataAdapter(query, con))
            {
                con.Open();
                da.Fill(ds);
                con.Close();
                return ds;

            }
        }
        public DataSet PostCustomer(string dbParam)
        {
            DbConnections conobj = new DbConnections();
            var con = conobj.connection(dbParam);
            DataSet ds = new DataSet();
            string query = "";
            //query = "Select CompanyId, CustomerName From tblCompany Order By CustomerName";
            query += "INSERT INTO tblCompany";
            query += "(CustomerId, CustomerName)";
            query += "Values('232', 'navdeep')";

            query += "Select CompanyId, CustomerName From tblCompany Order By CustomerName";
            using (SqlDataAdapter da = new SqlDataAdapter(query, con))
            {
                con.Open();
                da.Fill(ds);
                return ds;
            }
        }
    }
}