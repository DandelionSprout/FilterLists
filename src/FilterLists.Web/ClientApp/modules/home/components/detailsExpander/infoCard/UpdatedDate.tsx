import * as React from "react";
import * as moment from "moment";

interface IProps {
    updatedDate: string;
};

export const UpdatedDate = (props: IProps) =>
    props.updatedDate
    ? <li className="list-group-item">
          <p>Updated: {moment(props.updatedDate).isValid()
                           ? moment(props.updatedDate).DateTimeFormat(["utc"]).format(date)
                           : "N/A"}</p>
      </li>
    : null;
