    [Net.ServicePointManager]::SecurityProtocol = [Net.SecurityProtocolType]::Tls12
    $urlBase = "https://localhost:7205/api/"

    $credenciais = @{
        UserName = 'Jailson Silva'
        Password = '491'
    } | ConvertTo-Json

    $retornoLogin = $null

    $retornoLogin = Invoke-RestMethod  -Uri ($urlBase + "Token") -Method POST -ContentType "application/json" -Body $credenciais
    
    if ($retornoLogin) {

        $url_API_Users = ($urlBase + "Users/V1/ListUser")

        $headers = @{
            Authorization = "Bearer " + $retornoLogin.accessToken
        }     

        $Users = Invoke-RestMethod  -Uri $url_API_Users -Headers $headers -Method GET -ContentType "application/json"

       return $Users | Export-Csv -Path .\User.csv

    }


