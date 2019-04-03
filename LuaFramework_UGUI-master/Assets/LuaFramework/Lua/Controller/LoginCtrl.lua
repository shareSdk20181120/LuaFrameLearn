LoginCtrl={};
local this=LoginCtrl;
local gameObject;
local transform;
local message;

function LoginCtrl.New()
	logWarn("LoginCtrl.New--->")
	return this;
end

function LoginCtrl.Awake()
	logWarn("LoginCtrl.Awake");
	panelMgr:CreatePanel("Login",this.OnCreate);
end

function LoginCtrl.OnCreate(obj)
	logWarn("LoginCtrl.OnCreate");
	gameObject=obj;
	transform=gameObject.transform;
	message=gameObject:GetComponent("LuaBehaviour");
	message:AddClick(LoginPanel.loginBtn,this.LoginBtnClick);
end


function LoginCtrl.LoginBtnClick(go)
	logWarn("loginBtn click");

end