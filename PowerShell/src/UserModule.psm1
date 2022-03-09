function GetUser {
    param (
        [string] $name,
        [string] $_password
    )        
    [Net.ServicePointManager]::SecurityProtocol = [Net.SecurityProtocolType]::Tls12
    $urlBase = "https://localhost:7205/api/"

    $retornoLogin = $null

    $retornoLogin = Invoke-RestMethod  -Uri ($urlBase + "Token") -Method POST -ContentType "application/json" -Body $credenciais
    
    if ($retornoLogin){

        $url_API_Users = ($urlBase + "Users/V1/ListUser")

        $headers = @{
            Authorization = "Bearer " + $retornoLogin.accessToken
        }     

        $Users = Invoke-RestMethod  -Uri $url_API_Users -Headers $headers -Method GET -ContentType "application/json"

       return $Users | Export-Csv -Path .\User.csv

    }
}

Export-ModuleMember -function GetUser
