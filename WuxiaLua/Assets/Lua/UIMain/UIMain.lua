luanet.load_assembly('UnityEngine')
luanet.load_assembly('UnityEngine.UI')
GameObject = luanet.import_type('UnityEngine.GameObject')
AuthCode = luanet.import_type('UnityEngine.AuthCode')

function Login(accountGo, PassGo)
	local InputField = luanet.import_type('UnityEngine.UI.InputField')
	if Check(accountGo) and Check(PassGo) then
		local account = accountGo:GetComponent(luanet.ctype(InputField)).text
		local pass = PassGo:GetComponent(luanet.ctype(InputField)).text
		local WWW = luanet.import_type('UnityEngine.WWW')
		local wwwRequest = WWW("121.40.214.33:8080")
		local WaitRequest = coroutine.create(function(www)
			if www.isDone==false then 
				--coroutine.yield();
				coroutine.resume(WaitRequest, wwwRequest)
			end
		end)
		coroutine.resume(WaitRequest, wwwRequest)
		return false,wwwRequest.text
	else
		return false,"请检查输入的账号或密码"
	end
end



function Check(go)
	local InputField = luanet.import_type('UnityEngine.UI.InputField')
	local inputText = go:GetComponent(luanet.ctype(InputField)).text
	if string.len(inputText)>=6 and string.len(inputText)<=15 then
		return true
	else
		return false
	end
	
end
