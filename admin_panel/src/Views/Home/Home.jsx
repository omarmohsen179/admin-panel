import SubmitButtons from "../../Components/Buttons/SubmitButtons";
import CardForm from "../../Components/CardForm/CardForm";
import LabeledInput from "../../Components/Inputs/LabeledInput";
function Home() {
  return (
    <div className="content">
      <CardForm title="submit Form">
        <LabeledInput Label={"title"} />

        <LabeledInput Label={"details"} />
        <SubmitButtons />
      </CardForm>
    </div>
  );
}

export default Home;
