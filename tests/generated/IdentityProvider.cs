// Generated by the protocol buffer compiler.  DO NOT EDIT!
// source: sso/v1/identity_provider.proto
#pragma warning disable 1591, 0612, 3021
#region Designer generated code

using pb = global::Google.Protobuf;
using pbc = global::Google.Protobuf.Collections;
using pbr = global::Google.Protobuf.Reflection;
using scg = global::System.Collections.Generic;
namespace Sso.V1 {

  /// <summary>Holder for reflection information generated from sso/v1/identity_provider.proto</summary>
  public static partial class IdentityProviderReflection {

    #region Descriptor
    /// <summary>File descriptor for sso/v1/identity_provider.proto</summary>
    public static pbr::FileDescriptor Descriptor {
      get { return descriptor; }
    }
    private static pbr::FileDescriptor descriptor;

    static IdentityProviderReflection() {
      byte[] descriptorData = global::System.Convert.FromBase64String(
          string.Concat(
            "Ch5zc28vdjEvaWRlbnRpdHlfcHJvdmlkZXIucHJvdG8SBnNzby52MRodc3Nv",
            "L3YxL3NlcnZpY2VfcHJvdmlkZXIucHJvdG8iWgoSR2V0RW50cnlVUkxSZXF1",
            "ZXN0EhsKE3NlcnZpY2VfcHJvdmlkZXJfaWQYASABKAkSJwoHY29udGV4dBgC",
            "IAEoCzIWLnNzby52MS5TZXJ2aWNlQ29udGV4dCIoChNHZXRFbnRyeVVSTFJl",
            "c3BvbnNlEhEKCWVudHJ5X3VybBgBIAEoCSKoAQoaR2V0RW50cnlVUkxXaXRo",
            "Q29kZVJlcXVlc3QSGwoTc2VydmljZV9wcm92aWRlcl9pZBgBIAEoCRISCgpz",
            "ZXNzaW9uX2lkGAIgASgJEg8KB3VzZXJfaWQYAyABKAkSDQoFZW1haWwYBCAB",
            "KAkSJwoHY29udGV4dBgFIAEoCzIWLnNzby52MS5TZXJ2aWNlQ29udGV4dBIQ",
            "CghuZXh0X3VybBgGIAEoCSIwChtHZXRFbnRyeVVSTFdpdGhDb2RlUmVzcG9u",
            "c2USEQoJZW50cnlfdXJsGAEgASgJIiMKDUxvZ291dFJlcXVlc3QSEgoKc2Vz",
            "c2lvbl9pZBgBIAEoCUInChNjb20udmVuZGFzdGEuc3NvLnYxQhBJZGVudGl0",
            "eVByb3ZpZGVyYgZwcm90bzM="));
      descriptor = pbr::FileDescriptor.FromGeneratedCode(descriptorData,
          new pbr::FileDescriptor[] { global::Sso.V1.ServiceProviderReflection.Descriptor, },
          new pbr::GeneratedClrTypeInfo(null, new pbr::GeneratedClrTypeInfo[] {
            new pbr::GeneratedClrTypeInfo(typeof(global::Sso.V1.GetEntryURLRequest), global::Sso.V1.GetEntryURLRequest.Parser, new[]{ "ServiceProviderId", "Context" }, null, null, null),
            new pbr::GeneratedClrTypeInfo(typeof(global::Sso.V1.GetEntryURLResponse), global::Sso.V1.GetEntryURLResponse.Parser, new[]{ "EntryUrl" }, null, null, null),
            new pbr::GeneratedClrTypeInfo(typeof(global::Sso.V1.GetEntryURLWithCodeRequest), global::Sso.V1.GetEntryURLWithCodeRequest.Parser, new[]{ "ServiceProviderId", "SessionId", "UserId", "Email", "Context", "NextUrl" }, null, null, null),
            new pbr::GeneratedClrTypeInfo(typeof(global::Sso.V1.GetEntryURLWithCodeResponse), global::Sso.V1.GetEntryURLWithCodeResponse.Parser, new[]{ "EntryUrl" }, null, null, null),
            new pbr::GeneratedClrTypeInfo(typeof(global::Sso.V1.LogoutRequest), global::Sso.V1.LogoutRequest.Parser, new[]{ "SessionId" }, null, null, null)
          }));
    }
    #endregion

  }
  #region Messages
  public sealed partial class GetEntryURLRequest : pb::IMessage<GetEntryURLRequest> {
    private static readonly pb::MessageParser<GetEntryURLRequest> _parser = new pb::MessageParser<GetEntryURLRequest>(() => new GetEntryURLRequest());
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public static pb::MessageParser<GetEntryURLRequest> Parser { get { return _parser; } }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public static pbr::MessageDescriptor Descriptor {
      get { return global::Sso.V1.IdentityProviderReflection.Descriptor.MessageTypes[0]; }
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    pbr::MessageDescriptor pb::IMessage.Descriptor {
      get { return Descriptor; }
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public GetEntryURLRequest() {
      OnConstruction();
    }

    partial void OnConstruction();

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public GetEntryURLRequest(GetEntryURLRequest other) : this() {
      serviceProviderId_ = other.serviceProviderId_;
      Context = other.context_ != null ? other.Context.Clone() : null;
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public GetEntryURLRequest Clone() {
      return new GetEntryURLRequest(this);
    }

    /// <summary>Field number for the "service_provider_id" field.</summary>
    public const int ServiceProviderIdFieldNumber = 1;
    private string serviceProviderId_ = "";
    /// <summary>
    /// The service provider ID.
    /// </summary>
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public string ServiceProviderId {
      get { return serviceProviderId_; }
      set {
        serviceProviderId_ = pb::ProtoPreconditions.CheckNotNull(value, "value");
      }
    }

    /// <summary>Field number for the "context" field.</summary>
    public const int ContextFieldNumber = 2;
    private global::Sso.V1.ServiceContext context_;
    /// <summary>
    /// See ServiceContext for more information.
    /// </summary>
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public global::Sso.V1.ServiceContext Context {
      get { return context_; }
      set {
        context_ = value;
      }
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public override bool Equals(object other) {
      return Equals(other as GetEntryURLRequest);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public bool Equals(GetEntryURLRequest other) {
      if (ReferenceEquals(other, null)) {
        return false;
      }
      if (ReferenceEquals(other, this)) {
        return true;
      }
      if (ServiceProviderId != other.ServiceProviderId) return false;
      if (!object.Equals(Context, other.Context)) return false;
      return true;
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public override int GetHashCode() {
      int hash = 1;
      if (ServiceProviderId.Length != 0) hash ^= ServiceProviderId.GetHashCode();
      if (context_ != null) hash ^= Context.GetHashCode();
      return hash;
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public override string ToString() {
      return pb::JsonFormatter.ToDiagnosticString(this);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public void WriteTo(pb::CodedOutputStream output) {
      if (ServiceProviderId.Length != 0) {
        output.WriteRawTag(10);
        output.WriteString(ServiceProviderId);
      }
      if (context_ != null) {
        output.WriteRawTag(18);
        output.WriteMessage(Context);
      }
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public int CalculateSize() {
      int size = 0;
      if (ServiceProviderId.Length != 0) {
        size += 1 + pb::CodedOutputStream.ComputeStringSize(ServiceProviderId);
      }
      if (context_ != null) {
        size += 1 + pb::CodedOutputStream.ComputeMessageSize(Context);
      }
      return size;
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public void MergeFrom(GetEntryURLRequest other) {
      if (other == null) {
        return;
      }
      if (other.ServiceProviderId.Length != 0) {
        ServiceProviderId = other.ServiceProviderId;
      }
      if (other.context_ != null) {
        if (context_ == null) {
          context_ = new global::Sso.V1.ServiceContext();
        }
        Context.MergeFrom(other.Context);
      }
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public void MergeFrom(pb::CodedInputStream input) {
      uint tag;
      while ((tag = input.ReadTag()) != 0) {
        switch(tag) {
          default:
            input.SkipLastField();
            break;
          case 10: {
            ServiceProviderId = input.ReadString();
            break;
          }
          case 18: {
            if (context_ == null) {
              context_ = new global::Sso.V1.ServiceContext();
            }
            input.ReadMessage(context_);
            break;
          }
        }
      }
    }

  }

  public sealed partial class GetEntryURLResponse : pb::IMessage<GetEntryURLResponse> {
    private static readonly pb::MessageParser<GetEntryURLResponse> _parser = new pb::MessageParser<GetEntryURLResponse>(() => new GetEntryURLResponse());
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public static pb::MessageParser<GetEntryURLResponse> Parser { get { return _parser; } }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public static pbr::MessageDescriptor Descriptor {
      get { return global::Sso.V1.IdentityProviderReflection.Descriptor.MessageTypes[1]; }
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    pbr::MessageDescriptor pb::IMessage.Descriptor {
      get { return Descriptor; }
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public GetEntryURLResponse() {
      OnConstruction();
    }

    partial void OnConstruction();

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public GetEntryURLResponse(GetEntryURLResponse other) : this() {
      entryUrl_ = other.entryUrl_;
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public GetEntryURLResponse Clone() {
      return new GetEntryURLResponse(this);
    }

    /// <summary>Field number for the "entry_url" field.</summary>
    public const int EntryUrlFieldNumber = 1;
    private string entryUrl_ = "";
    /// <summary>
    /// The entry URL
    /// </summary>
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public string EntryUrl {
      get { return entryUrl_; }
      set {
        entryUrl_ = pb::ProtoPreconditions.CheckNotNull(value, "value");
      }
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public override bool Equals(object other) {
      return Equals(other as GetEntryURLResponse);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public bool Equals(GetEntryURLResponse other) {
      if (ReferenceEquals(other, null)) {
        return false;
      }
      if (ReferenceEquals(other, this)) {
        return true;
      }
      if (EntryUrl != other.EntryUrl) return false;
      return true;
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public override int GetHashCode() {
      int hash = 1;
      if (EntryUrl.Length != 0) hash ^= EntryUrl.GetHashCode();
      return hash;
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public override string ToString() {
      return pb::JsonFormatter.ToDiagnosticString(this);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public void WriteTo(pb::CodedOutputStream output) {
      if (EntryUrl.Length != 0) {
        output.WriteRawTag(10);
        output.WriteString(EntryUrl);
      }
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public int CalculateSize() {
      int size = 0;
      if (EntryUrl.Length != 0) {
        size += 1 + pb::CodedOutputStream.ComputeStringSize(EntryUrl);
      }
      return size;
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public void MergeFrom(GetEntryURLResponse other) {
      if (other == null) {
        return;
      }
      if (other.EntryUrl.Length != 0) {
        EntryUrl = other.EntryUrl;
      }
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public void MergeFrom(pb::CodedInputStream input) {
      uint tag;
      while ((tag = input.ReadTag()) != 0) {
        switch(tag) {
          default:
            input.SkipLastField();
            break;
          case 10: {
            EntryUrl = input.ReadString();
            break;
          }
        }
      }
    }

  }

  public sealed partial class GetEntryURLWithCodeRequest : pb::IMessage<GetEntryURLWithCodeRequest> {
    private static readonly pb::MessageParser<GetEntryURLWithCodeRequest> _parser = new pb::MessageParser<GetEntryURLWithCodeRequest>(() => new GetEntryURLWithCodeRequest());
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public static pb::MessageParser<GetEntryURLWithCodeRequest> Parser { get { return _parser; } }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public static pbr::MessageDescriptor Descriptor {
      get { return global::Sso.V1.IdentityProviderReflection.Descriptor.MessageTypes[2]; }
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    pbr::MessageDescriptor pb::IMessage.Descriptor {
      get { return Descriptor; }
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public GetEntryURLWithCodeRequest() {
      OnConstruction();
    }

    partial void OnConstruction();

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public GetEntryURLWithCodeRequest(GetEntryURLWithCodeRequest other) : this() {
      serviceProviderId_ = other.serviceProviderId_;
      sessionId_ = other.sessionId_;
      userId_ = other.userId_;
      email_ = other.email_;
      Context = other.context_ != null ? other.Context.Clone() : null;
      nextUrl_ = other.nextUrl_;
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public GetEntryURLWithCodeRequest Clone() {
      return new GetEntryURLWithCodeRequest(this);
    }

    /// <summary>Field number for the "service_provider_id" field.</summary>
    public const int ServiceProviderIdFieldNumber = 1;
    private string serviceProviderId_ = "";
    /// <summary>
    /// The service provider ID.    
    /// </summary>
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public string ServiceProviderId {
      get { return serviceProviderId_; }
      set {
        serviceProviderId_ = pb::ProtoPreconditions.CheckNotNull(value, "value");
      }
    }

    /// <summary>Field number for the "session_id" field.</summary>
    public const int SessionIdFieldNumber = 2;
    private string sessionId_ = "";
    /// <summary>
    /// The session ID the identity provider wants to pass along to the service providers.
    /// </summary>
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public string SessionId {
      get { return sessionId_; }
      set {
        sessionId_ = pb::ProtoPreconditions.CheckNotNull(value, "value");
      }
    }

    /// <summary>Field number for the "user_id" field.</summary>
    public const int UserIdFieldNumber = 3;
    private string userId_ = "";
    /// <summary>
    /// The user ID.
    /// </summary>
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public string UserId {
      get { return userId_; }
      set {
        userId_ = pb::ProtoPreconditions.CheckNotNull(value, "value");
      }
    }

    /// <summary>Field number for the "email" field.</summary>
    public const int EmailFieldNumber = 4;
    private string email_ = "";
    /// <summary>
    /// The user's email.
    /// </summary>
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public string Email {
      get { return email_; }
      set {
        email_ = pb::ProtoPreconditions.CheckNotNull(value, "value");
      }
    }

    /// <summary>Field number for the "context" field.</summary>
    public const int ContextFieldNumber = 5;
    private global::Sso.V1.ServiceContext context_;
    /// <summary>
    /// The service context needed to help determine which identity provider to use.
    /// </summary>
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public global::Sso.V1.ServiceContext Context {
      get { return context_; }
      set {
        context_ = value;
      }
    }

    /// <summary>Field number for the "next_url" field.</summary>
    public const int NextUrlFieldNumber = 6;
    private string nextUrl_ = "";
    /// <summary>
    /// The next URL to send the user to, once the code exchange is complete on the entry URL.
    /// </summary>
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public string NextUrl {
      get { return nextUrl_; }
      set {
        nextUrl_ = pb::ProtoPreconditions.CheckNotNull(value, "value");
      }
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public override bool Equals(object other) {
      return Equals(other as GetEntryURLWithCodeRequest);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public bool Equals(GetEntryURLWithCodeRequest other) {
      if (ReferenceEquals(other, null)) {
        return false;
      }
      if (ReferenceEquals(other, this)) {
        return true;
      }
      if (ServiceProviderId != other.ServiceProviderId) return false;
      if (SessionId != other.SessionId) return false;
      if (UserId != other.UserId) return false;
      if (Email != other.Email) return false;
      if (!object.Equals(Context, other.Context)) return false;
      if (NextUrl != other.NextUrl) return false;
      return true;
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public override int GetHashCode() {
      int hash = 1;
      if (ServiceProviderId.Length != 0) hash ^= ServiceProviderId.GetHashCode();
      if (SessionId.Length != 0) hash ^= SessionId.GetHashCode();
      if (UserId.Length != 0) hash ^= UserId.GetHashCode();
      if (Email.Length != 0) hash ^= Email.GetHashCode();
      if (context_ != null) hash ^= Context.GetHashCode();
      if (NextUrl.Length != 0) hash ^= NextUrl.GetHashCode();
      return hash;
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public override string ToString() {
      return pb::JsonFormatter.ToDiagnosticString(this);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public void WriteTo(pb::CodedOutputStream output) {
      if (ServiceProviderId.Length != 0) {
        output.WriteRawTag(10);
        output.WriteString(ServiceProviderId);
      }
      if (SessionId.Length != 0) {
        output.WriteRawTag(18);
        output.WriteString(SessionId);
      }
      if (UserId.Length != 0) {
        output.WriteRawTag(26);
        output.WriteString(UserId);
      }
      if (Email.Length != 0) {
        output.WriteRawTag(34);
        output.WriteString(Email);
      }
      if (context_ != null) {
        output.WriteRawTag(42);
        output.WriteMessage(Context);
      }
      if (NextUrl.Length != 0) {
        output.WriteRawTag(50);
        output.WriteString(NextUrl);
      }
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public int CalculateSize() {
      int size = 0;
      if (ServiceProviderId.Length != 0) {
        size += 1 + pb::CodedOutputStream.ComputeStringSize(ServiceProviderId);
      }
      if (SessionId.Length != 0) {
        size += 1 + pb::CodedOutputStream.ComputeStringSize(SessionId);
      }
      if (UserId.Length != 0) {
        size += 1 + pb::CodedOutputStream.ComputeStringSize(UserId);
      }
      if (Email.Length != 0) {
        size += 1 + pb::CodedOutputStream.ComputeStringSize(Email);
      }
      if (context_ != null) {
        size += 1 + pb::CodedOutputStream.ComputeMessageSize(Context);
      }
      if (NextUrl.Length != 0) {
        size += 1 + pb::CodedOutputStream.ComputeStringSize(NextUrl);
      }
      return size;
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public void MergeFrom(GetEntryURLWithCodeRequest other) {
      if (other == null) {
        return;
      }
      if (other.ServiceProviderId.Length != 0) {
        ServiceProviderId = other.ServiceProviderId;
      }
      if (other.SessionId.Length != 0) {
        SessionId = other.SessionId;
      }
      if (other.UserId.Length != 0) {
        UserId = other.UserId;
      }
      if (other.Email.Length != 0) {
        Email = other.Email;
      }
      if (other.context_ != null) {
        if (context_ == null) {
          context_ = new global::Sso.V1.ServiceContext();
        }
        Context.MergeFrom(other.Context);
      }
      if (other.NextUrl.Length != 0) {
        NextUrl = other.NextUrl;
      }
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public void MergeFrom(pb::CodedInputStream input) {
      uint tag;
      while ((tag = input.ReadTag()) != 0) {
        switch(tag) {
          default:
            input.SkipLastField();
            break;
          case 10: {
            ServiceProviderId = input.ReadString();
            break;
          }
          case 18: {
            SessionId = input.ReadString();
            break;
          }
          case 26: {
            UserId = input.ReadString();
            break;
          }
          case 34: {
            Email = input.ReadString();
            break;
          }
          case 42: {
            if (context_ == null) {
              context_ = new global::Sso.V1.ServiceContext();
            }
            input.ReadMessage(context_);
            break;
          }
          case 50: {
            NextUrl = input.ReadString();
            break;
          }
        }
      }
    }

  }

  public sealed partial class GetEntryURLWithCodeResponse : pb::IMessage<GetEntryURLWithCodeResponse> {
    private static readonly pb::MessageParser<GetEntryURLWithCodeResponse> _parser = new pb::MessageParser<GetEntryURLWithCodeResponse>(() => new GetEntryURLWithCodeResponse());
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public static pb::MessageParser<GetEntryURLWithCodeResponse> Parser { get { return _parser; } }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public static pbr::MessageDescriptor Descriptor {
      get { return global::Sso.V1.IdentityProviderReflection.Descriptor.MessageTypes[3]; }
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    pbr::MessageDescriptor pb::IMessage.Descriptor {
      get { return Descriptor; }
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public GetEntryURLWithCodeResponse() {
      OnConstruction();
    }

    partial void OnConstruction();

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public GetEntryURLWithCodeResponse(GetEntryURLWithCodeResponse other) : this() {
      entryUrl_ = other.entryUrl_;
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public GetEntryURLWithCodeResponse Clone() {
      return new GetEntryURLWithCodeResponse(this);
    }

    /// <summary>Field number for the "entry_url" field.</summary>
    public const int EntryUrlFieldNumber = 1;
    private string entryUrl_ = "";
    /// <summary>
    /// The entry URL, containing the code in the query params
    /// </summary>
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public string EntryUrl {
      get { return entryUrl_; }
      set {
        entryUrl_ = pb::ProtoPreconditions.CheckNotNull(value, "value");
      }
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public override bool Equals(object other) {
      return Equals(other as GetEntryURLWithCodeResponse);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public bool Equals(GetEntryURLWithCodeResponse other) {
      if (ReferenceEquals(other, null)) {
        return false;
      }
      if (ReferenceEquals(other, this)) {
        return true;
      }
      if (EntryUrl != other.EntryUrl) return false;
      return true;
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public override int GetHashCode() {
      int hash = 1;
      if (EntryUrl.Length != 0) hash ^= EntryUrl.GetHashCode();
      return hash;
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public override string ToString() {
      return pb::JsonFormatter.ToDiagnosticString(this);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public void WriteTo(pb::CodedOutputStream output) {
      if (EntryUrl.Length != 0) {
        output.WriteRawTag(10);
        output.WriteString(EntryUrl);
      }
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public int CalculateSize() {
      int size = 0;
      if (EntryUrl.Length != 0) {
        size += 1 + pb::CodedOutputStream.ComputeStringSize(EntryUrl);
      }
      return size;
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public void MergeFrom(GetEntryURLWithCodeResponse other) {
      if (other == null) {
        return;
      }
      if (other.EntryUrl.Length != 0) {
        EntryUrl = other.EntryUrl;
      }
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public void MergeFrom(pb::CodedInputStream input) {
      uint tag;
      while ((tag = input.ReadTag()) != 0) {
        switch(tag) {
          default:
            input.SkipLastField();
            break;
          case 10: {
            EntryUrl = input.ReadString();
            break;
          }
        }
      }
    }

  }

  public sealed partial class LogoutRequest : pb::IMessage<LogoutRequest> {
    private static readonly pb::MessageParser<LogoutRequest> _parser = new pb::MessageParser<LogoutRequest>(() => new LogoutRequest());
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public static pb::MessageParser<LogoutRequest> Parser { get { return _parser; } }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public static pbr::MessageDescriptor Descriptor {
      get { return global::Sso.V1.IdentityProviderReflection.Descriptor.MessageTypes[4]; }
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    pbr::MessageDescriptor pb::IMessage.Descriptor {
      get { return Descriptor; }
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public LogoutRequest() {
      OnConstruction();
    }

    partial void OnConstruction();

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public LogoutRequest(LogoutRequest other) : this() {
      sessionId_ = other.sessionId_;
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public LogoutRequest Clone() {
      return new LogoutRequest(this);
    }

    /// <summary>Field number for the "session_id" field.</summary>
    public const int SessionIdFieldNumber = 1;
    private string sessionId_ = "";
    /// <summary>
    /// The session ID to logout
    /// </summary>
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public string SessionId {
      get { return sessionId_; }
      set {
        sessionId_ = pb::ProtoPreconditions.CheckNotNull(value, "value");
      }
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public override bool Equals(object other) {
      return Equals(other as LogoutRequest);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public bool Equals(LogoutRequest other) {
      if (ReferenceEquals(other, null)) {
        return false;
      }
      if (ReferenceEquals(other, this)) {
        return true;
      }
      if (SessionId != other.SessionId) return false;
      return true;
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public override int GetHashCode() {
      int hash = 1;
      if (SessionId.Length != 0) hash ^= SessionId.GetHashCode();
      return hash;
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public override string ToString() {
      return pb::JsonFormatter.ToDiagnosticString(this);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public void WriteTo(pb::CodedOutputStream output) {
      if (SessionId.Length != 0) {
        output.WriteRawTag(10);
        output.WriteString(SessionId);
      }
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public int CalculateSize() {
      int size = 0;
      if (SessionId.Length != 0) {
        size += 1 + pb::CodedOutputStream.ComputeStringSize(SessionId);
      }
      return size;
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public void MergeFrom(LogoutRequest other) {
      if (other == null) {
        return;
      }
      if (other.SessionId.Length != 0) {
        SessionId = other.SessionId;
      }
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public void MergeFrom(pb::CodedInputStream input) {
      uint tag;
      while ((tag = input.ReadTag()) != 0) {
        switch(tag) {
          default:
            input.SkipLastField();
            break;
          case 10: {
            SessionId = input.ReadString();
            break;
          }
        }
      }
    }

  }

  #endregion

}

#endregion Designer generated code
