import { useEffect, useState } from "react";
import SubmitButtons from "../../Components/Buttons/SubmitButtons";
import CardForm from "../../Components/CardForm/CardForm";
import LabeledInput from "../../Components/Inputs/LabeledInput";
import Benefits from "./Components/Benefits";
import Member from "./Components/Members";
import MembersForm from "./Components/MembersForm";
import Steps from "./Components/Steps";
import { STEPS } from "./Home.Api";
import "./Home.css";
function Home() {
  return (
    <div className="content">
      <Steps />
      <Benefits />
      <Member />
    </div>
  );
}

export default Home;
