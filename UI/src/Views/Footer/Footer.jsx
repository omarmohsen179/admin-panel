import { useCallback, useEffect, useState } from "react";
import Section from "../../Components/Sections/Section";
import { SECTION_PAGE } from "../Home/Home.Api";

function Footer() {
  let [data, setdata] = useState([]);
  useEffect(async () => {
    await SECTION_PAGE("footer")
      .then((res) => {
        setdata(res);
      })
      .catch(() => {});
  }, []);
  const HandleChange = useCallback(
    (sid, Id, value, name) => {
      let va = data.map((ele) => {
        if (ele.Id == sid) {
          ele.Text = ele.Text.map((da) => {
            console.log(da.Id === Id ? { ...da, [name]: value } : { ...da });
            return da.Id === Id ? { ...da, [name]: value } : { ...da };
          });
        }
        return { ...ele };
      });

      setdata(va);
    },
    [data]
  );
  const HandleChangeImage = useCallback(
    (sid, value) => {
      let va = data.map((ele) => {
        if (ele.Id == sid) {
          ele.Imageup = value;
          ele.Image.ImagePath = "";
        }
        return { ...ele };
      });

      setdata(va);
    },
    [data]
  );
  const HandleChangesubmit = useCallback(
    (value) => {
      let va = data.map((ele) => {
        if (ele.Id == value.Id) {
          ele = value;
        }
        return { ...ele };
      });

      setdata(va);
    },
    [data]
  );

  return (
    <div className="content">
      <Section
        data={data?.filter((da) => da.Index == 1)[0]}
        HandleChange={HandleChange}
        setdata={HandleChangeImage}
        submit={HandleChangesubmit}
      />
    </div>
  );
}

export default Footer;
