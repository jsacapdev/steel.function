# Strongly Typed Configuration and Storage using v12 Storage and Role Based Access Control

`az group create -n st.cfg.str.rbac -l northeurope --debug`

`az group deployment create --name $(New-Guid) --resource-group st.cfg.str.rbac --template-file ./appinsights.template.json --parameters "AppInsightsName=stcfgstrrbac" --debug`

`az deployment group create --resource-group st.cfg.str.rbac --template-file ./storage.template.json --parameters StorageAccountName="stcfgstrrbac" --debug`

`az deployment group create --resource-group st.cfg.str.rbac --template-file ./function.template.json --parameters StorageAccountName=stcfgstrrbac AppInsightsName=stcfgstrrbac AppServicePlanName=stcfgstrrbac FunctionAppName=stcfgstrrbac --debug`

`func azure functionapp fetch-app-settings stcfgstrrbac`

`func azure functionapp publish stcfgstrrbac`

or if you want to do 2 things (zip and deploy):

`az functionapp deployment source config-zip -g st.cfg.str.rbac -n stcfgstrrbac --src d:/api/api.zip --debug`

`func azure functionapp list-functions stcfgstrrbac --browser --show-keys`
