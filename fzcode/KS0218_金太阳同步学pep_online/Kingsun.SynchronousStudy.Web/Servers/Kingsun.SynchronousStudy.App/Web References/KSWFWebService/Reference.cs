﻿//------------------------------------------------------------------------------
// <auto-generated>
//     此代码由工具生成。
//     运行时版本:4.0.30319.42000
//
//     对此文件的更改可能会导致不正确的行为，并且如果
//     重新生成代码，这些更改将会丢失。
// </auto-generated>
//------------------------------------------------------------------------------

// 
// 此源代码是由 Microsoft.VSDesigner 4.0.30319.42000 版自动生成。
// 
#pragma warning disable 1591

namespace Kingsun.SynchronousStudy.App.KSWFWebService {
    using System;
    using System.Web.Services;
    using System.Diagnostics;
    using System.Web.Services.Protocols;
    using System.Xml.Serialization;
    using System.ComponentModel;
    
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.6.81.0")]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Web.Services.WebServiceBindingAttribute(Name="KSWFWebServiceSoap", Namespace="http://tempuri.org/")]
    public partial class KSWFWebService : System.Web.Services.Protocols.SoapHttpClientProtocol {
        
        private CertficateSoapHeader certficateSoapHeaderValueField;
        
        private System.Threading.SendOrPostCallback AddProductOperationCompleted;
        
        private System.Threading.SendOrPostCallback AddOrderInfoOperationCompleted;
        
        private bool useDefaultCredentialsSetExplicitly;
        
        /// <remarks/>
        public KSWFWebService() {
            this.Url = global::Kingsun.SynchronousStudy.App.Properties.Settings.Default.Kingsun_SynchronousStudy_App_KSWFWebService_KSWFWebService;
            if ((this.IsLocalFileSystemWebService(this.Url) == true)) {
                this.UseDefaultCredentials = true;
                this.useDefaultCredentialsSetExplicitly = false;
            }
            else {
                this.useDefaultCredentialsSetExplicitly = true;
            }
        }
        
        public CertficateSoapHeader CertficateSoapHeaderValue {
            get {
                return this.certficateSoapHeaderValueField;
            }
            set {
                this.certficateSoapHeaderValueField = value;
            }
        }
        
        public new string Url {
            get {
                return base.Url;
            }
            set {
                if ((((this.IsLocalFileSystemWebService(base.Url) == true) 
                            && (this.useDefaultCredentialsSetExplicitly == false)) 
                            && (this.IsLocalFileSystemWebService(value) == false))) {
                    base.UseDefaultCredentials = false;
                }
                base.Url = value;
            }
        }
        
        public new bool UseDefaultCredentials {
            get {
                return base.UseDefaultCredentials;
            }
            set {
                base.UseDefaultCredentials = value;
                this.useDefaultCredentialsSetExplicitly = true;
            }
        }
        
        /// <remarks/>
        public event AddProductCompletedEventHandler AddProductCompleted;
        
        /// <remarks/>
        public event AddOrderInfoCompletedEventHandler AddOrderInfoCompleted;
        
        /// <remarks/>
        [System.Web.Services.Protocols.SoapHeaderAttribute("CertficateSoapHeaderValue")]
        [System.Web.Services.Protocols.SoapDocumentMethodAttribute("http://tempuri.org/AddProduct", RequestNamespace="http://tempuri.org/", ResponseNamespace="http://tempuri.org/", Use=System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle=System.Web.Services.Protocols.SoapParameterStyle.Wrapped)]
        public ReturnInfo AddProduct(Product productInfo) {
            object[] results = this.Invoke("AddProduct", new object[] {
                        productInfo});
            return ((ReturnInfo)(results[0]));
        }
        
        /// <remarks/>
        public void AddProductAsync(Product productInfo) {
            this.AddProductAsync(productInfo, null);
        }
        
        /// <remarks/>
        public void AddProductAsync(Product productInfo, object userState) {
            if ((this.AddProductOperationCompleted == null)) {
                this.AddProductOperationCompleted = new System.Threading.SendOrPostCallback(this.OnAddProductOperationCompleted);
            }
            this.InvokeAsync("AddProduct", new object[] {
                        productInfo}, this.AddProductOperationCompleted, userState);
        }
        
        private void OnAddProductOperationCompleted(object arg) {
            if ((this.AddProductCompleted != null)) {
                System.Web.Services.Protocols.InvokeCompletedEventArgs invokeArgs = ((System.Web.Services.Protocols.InvokeCompletedEventArgs)(arg));
                this.AddProductCompleted(this, new AddProductCompletedEventArgs(invokeArgs.Results, invokeArgs.Error, invokeArgs.Cancelled, invokeArgs.UserState));
            }
        }
        
        /// <remarks/>
        [System.Web.Services.Protocols.SoapHeaderAttribute("CertficateSoapHeaderValue")]
        [System.Web.Services.Protocols.SoapDocumentMethodAttribute("http://tempuri.org/AddOrderInfo", RequestNamespace="http://tempuri.org/", ResponseNamespace="http://tempuri.org/", Use=System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle=System.Web.Services.Protocols.SoapParameterStyle.Wrapped)]
        public ReturnInfo AddOrderInfo(Order oInfo) {
            object[] results = this.Invoke("AddOrderInfo", new object[] {
                        oInfo});
            return ((ReturnInfo)(results[0]));
        }
        
        /// <remarks/>
        public void AddOrderInfoAsync(Order oInfo) {
            this.AddOrderInfoAsync(oInfo, null);
        }
        
        /// <remarks/>
        public void AddOrderInfoAsync(Order oInfo, object userState) {
            if ((this.AddOrderInfoOperationCompleted == null)) {
                this.AddOrderInfoOperationCompleted = new System.Threading.SendOrPostCallback(this.OnAddOrderInfoOperationCompleted);
            }
            this.InvokeAsync("AddOrderInfo", new object[] {
                        oInfo}, this.AddOrderInfoOperationCompleted, userState);
        }
        
        private void OnAddOrderInfoOperationCompleted(object arg) {
            if ((this.AddOrderInfoCompleted != null)) {
                System.Web.Services.Protocols.InvokeCompletedEventArgs invokeArgs = ((System.Web.Services.Protocols.InvokeCompletedEventArgs)(arg));
                this.AddOrderInfoCompleted(this, new AddOrderInfoCompletedEventArgs(invokeArgs.Results, invokeArgs.Error, invokeArgs.Cancelled, invokeArgs.UserState));
            }
        }
        
        /// <remarks/>
        public new void CancelAsync(object userState) {
            base.CancelAsync(userState);
        }
        
        private bool IsLocalFileSystemWebService(string url) {
            if (((url == null) 
                        || (url == string.Empty))) {
                return false;
            }
            System.Uri wsUri = new System.Uri(url);
            if (((wsUri.Port >= 1024) 
                        && (string.Compare(wsUri.Host, "localHost", System.StringComparison.OrdinalIgnoreCase) == 0))) {
                return true;
            }
            return false;
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.6.81.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="http://tempuri.org/")]
    [System.Xml.Serialization.XmlRootAttribute(Namespace="http://tempuri.org/", IsNullable=false)]
    public partial class CertficateSoapHeader : System.Web.Services.Protocols.SoapHeader {
        
        private string userNameField;
        
        private string passWordField;
        
        private System.Xml.XmlAttribute[] anyAttrField;
        
        /// <remarks/>
        public string UserName {
            get {
                return this.userNameField;
            }
            set {
                this.userNameField = value;
            }
        }
        
        /// <remarks/>
        public string PassWord {
            get {
                return this.passWordField;
            }
            set {
                this.passWordField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlAnyAttributeAttribute()]
        public System.Xml.XmlAttribute[] AnyAttr {
            get {
                return this.anyAttrField;
            }
            set {
                this.anyAttrField = value;
            }
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.6.81.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="http://tempuri.org/")]
    public partial class Order {
        
        private string orderIDField;
        
        private System.Nullable<System.DateTime> orderDateField;
        
        private System.Nullable<int> areaIDField;
        
        private string areaPathField;
        
        private System.Nullable<int> schoolIDField;
        
        private string schoolNameField;
        
        private System.Nullable<int> gradeIDField;
        
        private string gradeNameField;
        
        private System.Nullable<System.Guid> classIDField;
        
        private string classNameField;
        
        private string productNOField;
        
        private string productNameField;
        
        private System.Nullable<int> teacherUserIDField;
        
        private string teacherUserNameField;
        
        private string buyUserIDField;
        
        private string buyUserPhoneField;
        
        private decimal payAmountField;
        
        private System.Nullable<int> payTypeField;
        
        private System.Nullable<int> channelField;
        
        private string userClientIPField;
        
        /// <remarks/>
        public string OrderID {
            get {
                return this.orderIDField;
            }
            set {
                this.orderIDField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(IsNullable=true)]
        public System.Nullable<System.DateTime> OrderDate {
            get {
                return this.orderDateField;
            }
            set {
                this.orderDateField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(IsNullable=true)]
        public System.Nullable<int> AreaID {
            get {
                return this.areaIDField;
            }
            set {
                this.areaIDField = value;
            }
        }
        
        /// <remarks/>
        public string AreaPath {
            get {
                return this.areaPathField;
            }
            set {
                this.areaPathField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(IsNullable=true)]
        public System.Nullable<int> SchoolID {
            get {
                return this.schoolIDField;
            }
            set {
                this.schoolIDField = value;
            }
        }
        
        /// <remarks/>
        public string SchoolName {
            get {
                return this.schoolNameField;
            }
            set {
                this.schoolNameField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(IsNullable=true)]
        public System.Nullable<int> GradeID {
            get {
                return this.gradeIDField;
            }
            set {
                this.gradeIDField = value;
            }
        }
        
        /// <remarks/>
        public string GradeName {
            get {
                return this.gradeNameField;
            }
            set {
                this.gradeNameField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(IsNullable=true)]
        public System.Nullable<System.Guid> ClassID {
            get {
                return this.classIDField;
            }
            set {
                this.classIDField = value;
            }
        }
        
        /// <remarks/>
        public string ClassName {
            get {
                return this.classNameField;
            }
            set {
                this.classNameField = value;
            }
        }
        
        /// <remarks/>
        public string ProductNO {
            get {
                return this.productNOField;
            }
            set {
                this.productNOField = value;
            }
        }
        
        /// <remarks/>
        public string ProductName {
            get {
                return this.productNameField;
            }
            set {
                this.productNameField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(IsNullable=true)]
        public System.Nullable<int> TeacherUserID {
            get {
                return this.teacherUserIDField;
            }
            set {
                this.teacherUserIDField = value;
            }
        }
        
        /// <remarks/>
        public string TeacherUserName {
            get {
                return this.teacherUserNameField;
            }
            set {
                this.teacherUserNameField = value;
            }
        }
        
        /// <remarks/>
        public string BuyUserID {
            get {
                return this.buyUserIDField;
            }
            set {
                this.buyUserIDField = value;
            }
        }
        
        /// <remarks/>
        public string BuyUserPhone {
            get {
                return this.buyUserPhoneField;
            }
            set {
                this.buyUserPhoneField = value;
            }
        }
        
        /// <remarks/>
        public decimal PayAmount {
            get {
                return this.payAmountField;
            }
            set {
                this.payAmountField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(IsNullable=true)]
        public System.Nullable<int> PayType {
            get {
                return this.payTypeField;
            }
            set {
                this.payTypeField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(IsNullable=true)]
        public System.Nullable<int> Channel {
            get {
                return this.channelField;
            }
            set {
                this.channelField = value;
            }
        }
        
        /// <remarks/>
        public string UserClientIP {
            get {
                return this.userClientIPField;
            }
            set {
                this.userClientIPField = value;
            }
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.6.81.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="http://tempuri.org/")]
    public partial class ReturnInfo {
        
        private bool successField;
        
        private string errorMsgField;
        
        /// <remarks/>
        public bool Success {
            get {
                return this.successField;
            }
            set {
                this.successField = value;
            }
        }
        
        /// <remarks/>
        public string ErrorMsg {
            get {
                return this.errorMsgField;
            }
            set {
                this.errorMsgField = value;
            }
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.6.81.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="http://tempuri.org/")]
    public partial class Product {
        
        private string productNameField;
        
        private System.Nullable<int> gradeIDField;
        
        private string gradeField;
        
        private System.Nullable<int> versionIDField;
        
        private string versionField;
        
        private System.Nullable<int> subjectIDField;
        
        private string subjectField;
        
        private string categoryField;
        
        private System.Nullable<int> categoryKeyField;
        
        private System.Nullable<int> idField;
        
        private string productNoField;
        
        private System.Nullable<int> channelField;
        
        private int isshevelField;
        
        private decimal priceField;
        
        private int delflgField;
        
        /// <remarks/>
        public string ProductName {
            get {
                return this.productNameField;
            }
            set {
                this.productNameField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(IsNullable=true)]
        public System.Nullable<int> GradeID {
            get {
                return this.gradeIDField;
            }
            set {
                this.gradeIDField = value;
            }
        }
        
        /// <remarks/>
        public string Grade {
            get {
                return this.gradeField;
            }
            set {
                this.gradeField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(IsNullable=true)]
        public System.Nullable<int> VersionID {
            get {
                return this.versionIDField;
            }
            set {
                this.versionIDField = value;
            }
        }
        
        /// <remarks/>
        public string Version {
            get {
                return this.versionField;
            }
            set {
                this.versionField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(IsNullable=true)]
        public System.Nullable<int> SubjectID {
            get {
                return this.subjectIDField;
            }
            set {
                this.subjectIDField = value;
            }
        }
        
        /// <remarks/>
        public string Subject {
            get {
                return this.subjectField;
            }
            set {
                this.subjectField = value;
            }
        }
        
        /// <remarks/>
        public string Category {
            get {
                return this.categoryField;
            }
            set {
                this.categoryField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(IsNullable=true)]
        public System.Nullable<int> CategoryKey {
            get {
                return this.categoryKeyField;
            }
            set {
                this.categoryKeyField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(IsNullable=true)]
        public System.Nullable<int> ID {
            get {
                return this.idField;
            }
            set {
                this.idField = value;
            }
        }
        
        /// <remarks/>
        public string ProductNo {
            get {
                return this.productNoField;
            }
            set {
                this.productNoField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(IsNullable=true)]
        public System.Nullable<int> Channel {
            get {
                return this.channelField;
            }
            set {
                this.channelField = value;
            }
        }
        
        /// <remarks/>
        public int Isshevel {
            get {
                return this.isshevelField;
            }
            set {
                this.isshevelField = value;
            }
        }
        
        /// <remarks/>
        public decimal Price {
            get {
                return this.priceField;
            }
            set {
                this.priceField = value;
            }
        }
        
        /// <remarks/>
        public int Delflg {
            get {
                return this.delflgField;
            }
            set {
                this.delflgField = value;
            }
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.6.81.0")]
    public delegate void AddProductCompletedEventHandler(object sender, AddProductCompletedEventArgs e);
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.6.81.0")]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    public partial class AddProductCompletedEventArgs : System.ComponentModel.AsyncCompletedEventArgs {
        
        private object[] results;
        
        internal AddProductCompletedEventArgs(object[] results, System.Exception exception, bool cancelled, object userState) : 
                base(exception, cancelled, userState) {
            this.results = results;
        }
        
        /// <remarks/>
        public ReturnInfo Result {
            get {
                this.RaiseExceptionIfNecessary();
                return ((ReturnInfo)(this.results[0]));
            }
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.6.81.0")]
    public delegate void AddOrderInfoCompletedEventHandler(object sender, AddOrderInfoCompletedEventArgs e);
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.6.81.0")]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    public partial class AddOrderInfoCompletedEventArgs : System.ComponentModel.AsyncCompletedEventArgs {
        
        private object[] results;
        
        internal AddOrderInfoCompletedEventArgs(object[] results, System.Exception exception, bool cancelled, object userState) : 
                base(exception, cancelled, userState) {
            this.results = results;
        }
        
        /// <remarks/>
        public ReturnInfo Result {
            get {
                this.RaiseExceptionIfNecessary();
                return ((ReturnInfo)(this.results[0]));
            }
        }
    }
}

#pragma warning restore 1591