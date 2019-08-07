// A controller is a class where the WebApi module will find available
// endpoints. The class must extend WebApiController.
using System;
using System.Threading.Tasks;
using Unosquare.Labs.EmbedIO;
using Unosquare.Labs.EmbedIO.Constants;
using Unosquare.Labs.EmbedIO.Modules;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActionController : WebApiController
{
    // You need to add a default constructor where the first argument
    // is an IHttpContext
    
    public ActionController(IHttpContext context)
        : base(context)
    {
    }

    // You need to include the WebApiHandler attribute to each method
    // where you want to export an endpoint. The method should return
    // bool or Task<bool>.

    [WebApiHandler(HttpVerbs.Get, "/api/action/{id}")]
    public async Task<bool> SendAction(int id)
    {
        try
        {
            //Console.WriteLine(action);
            
            Program.miigoInt = id;
            //UnityEngine.Debug.Log(Program.miigoInt);
            return await Ok(true);
        }
        catch (Exception ex)
        {
            return await InternalServerError(ex);
        }
    }

    [WebApiHandler(HttpVerbs.Get, "/api/action/game/{id}/{isCorrect}")]
    public async Task<bool> SendActionChoice(int id, int isCorrect)
    {
        try
        {
            Program.miigoCorrectChoiceInt = isCorrect;
            Program.miigoChoiceInt = id;
            //change the following 1 line later
            UnityEngine.Debug.Log("Correct answer is: " + Program.miigoCorrectChoiceInt);
            UnityEngine.Debug.Log("Your choice is: " + Program.miigoChoiceInt);
            ChangeFace();
            return await Ok(true);
        }
        catch (Exception ex)
        {
            return await InternalServerError(ex);
        }
    }

    void ChangeFace() {
        if (Program.miigoChoiceInt == 0)
        {
            Program.miigoInt = 4;
        }
        else if (Program.miigoChoiceInt == 1) {
            Program.miigoInt = 3;
        }
        else
        {
            Program.miigoInt = 0;
        }
    }

    // You can override the default headers and add custom headers to each API Response.
    public override void SetDefaultHeaders() => HttpContext.NoCache();
}