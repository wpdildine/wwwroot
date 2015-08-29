<%@ Control Language="C#" AutoEventWireup="true" CodeFile="ctrl_FloortimeSession.ascx.cs" Inherits="App_Controls_ctrl_FloortimeSession" %>
<%@ Register src="ctrl__Overlay_YourFT.ascx" tagname="ctrl__Overlay_YourFT" tagprefix="uc1" %>
<uc1:ctrl__Overlay_YourFT ID="ctrl__Overlay_YourFT1" runat="server" />
    
<div id="content">
    <h1 style="white-space:nowrap">Summing Up: Basic Concepts for Floortime</h1>
                  
    <p>Now that you’ve learned about the basic concepts of Floortime, you know that children are motivated by what already interests them.  Motivated children interact, engage, and have fun.  As you play with your child based on his or her own interests, you can help to build your relationship and connection with one another.  </p>
    <p>With time and practice, your relationship and your interactions become richer and longer.  As Dr. Greenspan says, positive emotions are the key to bringing a gleam to your child’s eye and helping them progress in relating, communicating, and thinking. </p>
      
    <div class="section sect_on" id="section1">

        <div class="num">1</div>
        <div class="cont">
            <span class="inst">To reflect on what you’ve learned so far, take a look at the Floortime session with Amberlee.  </span>
            <a href="#" onclick="toggleMedia('1');return false;" class="mediabtn mediabtn_long">Play Video #1
                <img src="/App_Images/ico_video_med_gold.png" alt="Play Video" />
                <span>Floortime session with Amberlee</span>
            </a>
            <div class="media_holder open" id="mholder_1">
                <iframe src="https://player.vimeo.com/video/124207883" width="948" height="711" frameborder="0" webkitallowfullscreen mozallowfullscreen allowfullscreen></iframe>
            </div>

        </div>

    </div>

    <div class="section sect_on" id="section2">

        <div class="num">2</div>
        <div class="cont">
            <%--<span class="inst">To reflect on what you’ve learned so far, take a look at the Floortime session with Amberlee.  </span>--%>
            <a href="#" onclick="turnOnSection('3');toggleMedia('2');return false;" class="mediabtn mediabtn_long">Play Video #2
                <img src="/App_Images/ico_video_med_gold.png" alt="Play Video" />
                <span>A short lecture by Dr. Greenspan about Amberlee’s potential.</span>
            </a>
            <div class="media_holder" id="mholder_2">
                <iframe src="https://player.vimeo.com/video/125474944" width="948" height="711" frameborder="0" webkitallowfullscreen mozallowfullscreen allowfullscreen></iframe>
            </div>

        </div>

    </div>

    <div class="section" id="section3">

        <div class="num">3</div>
        <div class="instructions">Please complete the previous step before continuing</div>
        <div class="cont">

            <div class="btn_holder">
                <label>Then fill out the evaluation sheet.</label>
                <a href="#" onclick="turnOnSection('4');DoEvaluation();return false;" class="btn btn_thin_red"><span>Do The Interactive Evaluation</span></a>

            </div>

        </div>

    </div>

    <div class="section" id="section4">

        <div class="num">4</div>
        <div class="instructions">Please complete the previous step before continuing</div>
        <div class="cont">

            <div class="btn_holder">
                <label>Once you have finished the interactive evaluation, move on to:</label>
                <a href="/en-us/yourFT/setup/default.aspx" class="btn btn_thin_blue"><span>Setting up your floortime session</span></a>

            </div>

        </div>

    </div>
</div>