<!-- Improved compatibility of back to top link: See: https://github.com/othneildrew/Best-README-Template/pull/73 -->
<a name="readme-top"></a>

<!-- PROJECT LOGO -->
<br />
<div align="center">
  <a href="https://github.com/LC-Organic-by-Komexeu/LC-Infrastructure">
  </a>

  <h3 align="center">LC-Infrastructure</h3>

  <p align="center">
    應用程式初始化
    <br />
  </p>
</div>



<!-- TABLE OF CONTENTS -->
<details>
  <summary>Table of Contents</summary>
  <ol>
    <li>
      <a href="#about-the-project">About The Project</a>
    </li>
    <li>
      <a href="#getting-started">Getting Started</a>
      <ul>
        <li><a href="#prerequisites">Prerequisites</a></li>
        <li><a href="#installation">Installation</a></li>
      </ul>
    </li>
    <li><a href="#usage">Usage</a></li>
    <li><a href="#roadmap">Roadmap</a></li>
  </ol>
</details>



<!-- ABOUT THE PROJECT -->
## About The Project

將`Program.cs`中，初始化設定應用程式的程式碼，以功能來分類，並使用`Builder Pattern`包裝，讓使用者可以選擇加入需要的功能。

<p align="right">(<a href="#readme-top">back to top</a>)</p>

<!-- GETTING STARTED -->
## Getting Started


### Prerequisites

建立一個新專案，並加入版控
* powershell
  ```pwsh
  dotnet new web -o MyProj
  cd MyProj
  git init
  git add .
  git commit -m "Init"
  ```

### Installation

1. 使用`git subtree`的方式將此包程式碼加入目標專案
   ```pwsh
   git subtree pull --prefix Infra https://github.com/LC-Organic-by-Komexeu/LC-Infrastructure.git master
   ```
2. 執行安裝
   ```pwsh
   cd Infra
   .\Go.ps1
   ```
3. 修改`Program.cs`
   ```csharp
    using LC.Infrastructure;
    namespace MyProj
    {
        /// <summary>Program</summary>
        public class Program
        {
            /// <summary>
            /// 程式進入點
            /// </summary>
            /// <param name="args"></param>
            public static void Main(string[] args)
            {

                var container = new ContainerInfrastructure();
                container
                    .AddInfrastructure(InfrastructureEnum.DI)
                    .AddInfrastructure(InfrastructureEnum.HealthCheck)
                    .AddInfrastructure(InfrastructureEnum.AppSettings)
                    .AddInfrastructure(InfrastructureEnum.Identity)
                    .AddInfrastructure(InfrastructureEnum.Authentication)
                    .AddInfrastructure(InfrastructureEnum.Authorization)
                    .AddInfrastructure(InfrastructureEnum.Route)
                    .AddInfrastructure(InfrastructureEnum.Cors)
                    .AddInfrastructure(InfrastructureEnum.Graphql)
                    .AddInfrastructure(InfrastructureEnum.Hangfire)
                    .AddInfrastructure(InfrastructureEnum.Swagger)
                    .AddInfrastructure(InfrastructureEnum.Mvc)
                    .AddInfrastructure(InfrastructureEnum.HttpClient)
                    .AddInfrastructure(InfrastructureEnum.Session)
                    .AddInfrastructure(InfrastructureEnum.Cache)
                    .AddInfrastructure(InfrastructureEnum.MainDatabase)
                    .AddInfrastructure(InfrastructureEnum.LogDatabase)
                    .AddInfrastructure(InfrastructureEnum.TaskDatabase)
                    .AddInfrastructure(InfrastructureEnum.Logger)
                    .AddInfrastructure(InfrastructureEnum.Files)
                    .AddInfrastructure(InfrastructureEnum.Security)
                    .Run(args);
            }
        }
    }

   ```

<p align="right">(<a href="#readme-top">back to top</a>)</p>



<!-- USAGE EXAMPLES -->
## Usage

1. 可使用的模組在`InfrastructureEnum`中

<p align="right">(<a href="#readme-top">back to top</a>)</p>



<!-- ROADMAP -->
## Roadmap

- [ ] Nuget套件化
- [ ] 測試

<p align="right">(<a href="#readme-top">back to top</a>)</p>