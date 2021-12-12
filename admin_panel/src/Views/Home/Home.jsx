import { useEffect, useState } from "react";
import SubmitButtons from "../../Components/Buttons/SubmitButtons";
import CardForm from "../../Components/CardForm/CardForm";
import LabeledInput from "../../Components/Inputs/LabeledInput";
import { STEPS } from "./Home.Api";
import "./Home.css";
function Home() {
  let [data, setdata] = useState([]);
  useEffect(() => {
    STEPS()
      .then((res) => {
        console.log(res);
        setdata(res);
      })
      .catch(() => {});
  }, []);

  return (
    <div className="content">
      <CardForm title=" Submit Form">
        {data.map((res, index) => {
          return (
            <div key={index} className="Home-steps-card">
              <div className="  number-circle">
                <div className="step-circle">
                  <p> {index + 1}</p>
                </div>
              </div>
              <div className="col">
                <div className="step-card-title">{res.Title}</div>
                <div className="decs-card-title">{res.Description}</div>
              </div>
            </div>
          );
        })}
      </CardForm>
    </div>
  );
}

export default Home;
